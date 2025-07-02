namespace SerumPresetGenerator.FxpFormat
{
    using System.IO;

    public class FxpPreset
    {
        public FxpHeader Header { get; set; } = new FxpHeader();
        public FxpPresetData PresetData { get; set; } = new FxpPresetData();

        private const int HeaderFixedSize = 4 + 4 + 4 + 4 + 4 + 4 + 4 + 32; // 60 bytes

        public void Load(string path)
        {
            using var fs = File.OpenRead(path);
            using var br = new BinaryReader(fs);

            Header.ReadFrom(br);

            int dataLength = Header.ChunkSize - HeaderFixedSize;
            // ChunkSize is total file size, subtract header size to get preset data length

            if (dataLength < 0)
                throw new InvalidDataException("Invalid chunk size or header size");

            PresetData.ReadFrom(br, dataLength);
        }

        public void Save(string path)
        {
            using var fs = File.Create(path);
            using var bw = new BinaryWriter(fs);

            // ChunkSize = total file size = header + preset data
            Header.ChunkSize = HeaderFixedSize + (PresetData?.RawData?.Length ?? 0);

            Header.WriteTo(bw);
            PresetData.WriteTo(bw);
        }
    }
}