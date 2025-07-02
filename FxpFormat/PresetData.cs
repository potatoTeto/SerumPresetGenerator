namespace SerumPresetGenerator.FxpFormat
{
    using System;
    using System.IO;

    public class PresetData
    {
        public byte[] RawData { get; set; } = Array.Empty<byte>();

        public void ReadFrom(BinaryReader br, int length)
        {
            RawData = br.ReadBytes(length);
        }

        public void WriteTo(BinaryWriter bw)
        {
            if (RawData != null && RawData.Length > 0)
                bw.Write(RawData);
        }
    }

}
