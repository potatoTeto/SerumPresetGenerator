namespace SerumPresetGenerator
{
    using System;
    using System.IO;
    using System.Text;

    public class FxpHeader
    {
        public string ChunkID { get; private set; } = "CcnK";
        public int ChunkSize { get; set; }
        public string ChunkType { get; private set; } = "FPCh";
        public int Version { get; private set; } = 1;
        public string PluginID { get; private set; } = "XfsX";
        public int Unknown1 { get; set; } = 1;
        public int Unknown2 { get; set; } = 1;
        public string PresetName { get; set; } = "Untitled";

        private const int PresetNameLength = 32;

        public void ReadFrom(BinaryReader br)
        {
            // ChunkID
            var chunkIdBytes = br.ReadBytes(4);
            ChunkID = Encoding.ASCII.GetString(chunkIdBytes);
            if (ChunkID != "CcnK")
                throw new InvalidDataException("Invalid ChunkID");

            // ChunkSize (big endian)
            var sizeBytes = br.ReadBytes(4);
            if (BitConverter.IsLittleEndian) Array.Reverse(sizeBytes);
            ChunkSize = BitConverter.ToInt32(sizeBytes, 0);

            // ChunkType
            var chunkTypeBytes = br.ReadBytes(4);
            ChunkType = Encoding.ASCII.GetString(chunkTypeBytes);
            if (ChunkType != "FPCh")
                throw new InvalidDataException("Invalid ChunkType");

            // Version (little endian)
            Version = br.ReadInt32();

            // PluginID
            var pluginIdBytes = br.ReadBytes(4);
            PluginID = Encoding.ASCII.GetString(pluginIdBytes);
            if (PluginID != "XfsX")
                throw new InvalidDataException("Unexpected PluginID");

            // Unknown1 & Unknown2
            Unknown1 = br.ReadInt32();
            Unknown2 = br.ReadInt32();

            // PresetName (32 bytes, null-padded)
            var nameBytes = br.ReadBytes(PresetNameLength);
            int nameLen = Array.IndexOf(nameBytes, (byte)0);
            if (nameLen < 0) nameLen = PresetNameLength;
            PresetName = Encoding.ASCII.GetString(nameBytes, 0, nameLen);
        }

        public void WriteTo(BinaryWriter bw)
        {
            bw.Write(Encoding.ASCII.GetBytes(ChunkID));

            // Calculate chunk size dynamically when saving, so must be set by caller before WriteTo
            var sizeBytes = BitConverter.GetBytes(ChunkSize);
            if (BitConverter.IsLittleEndian) Array.Reverse(sizeBytes);
            bw.Write(sizeBytes);

            bw.Write(Encoding.ASCII.GetBytes(ChunkType));
            bw.Write(Version);
            bw.Write(Encoding.ASCII.GetBytes(PluginID));
            bw.Write(Unknown1);
            bw.Write(Unknown2);

            var nameBytes = new byte[PresetNameLength];
            var presetNameBytes = Encoding.ASCII.GetBytes(PresetName);
            Array.Copy(presetNameBytes, nameBytes, Math.Min(presetNameBytes.Length, PresetNameLength));
            bw.Write(nameBytes);
        }
    }

}
