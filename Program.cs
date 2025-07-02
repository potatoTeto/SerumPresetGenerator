namespace SerumPresetGenerator
{
    using System;

    class Program
    {
        static void Main()
        {
            string filePath = "example.fxp";

            // Create a new preset
            var preset = new SerumFxpPreset();
            preset.Header.PresetName = "My Test Preset";

            // Fill PresetData with dummy bytes (for example purposes)
            preset.PresetData.RawData = new byte[100];
            for (int i = 0; i < preset.PresetData.RawData.Length; i++)
                preset.PresetData.RawData[i] = (byte)(i % 256);

            // Save the preset to file
            preset.Save(filePath);
            Console.WriteLine($"Saved preset '{preset.Header.PresetName}' with {preset.PresetData.RawData.Length} bytes of data.");

            // Load it back
            var loadedPreset = new SerumFxpPreset();
            loadedPreset.Load(filePath);

            Console.WriteLine($"Loaded preset '{loadedPreset.Header.PresetName}' with {loadedPreset.PresetData.RawData.Length} bytes of data.");
        }
    }
}
