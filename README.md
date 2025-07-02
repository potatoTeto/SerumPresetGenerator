# SerumPresetGenerator

**SerumPresetGenerator** is a C# library for programmatically generating and manipulating `.fxp` preset files compatible with [Xfer Serum](https://xferrecords.com/products/serum).

⚠️ This project is developed entirely through clean-room, independent analysis of publicly available `.fxp` files and does not use, depend on, or include any proprietary or reverse-engineered source code from Xfer Records or Serum.

---

## Features

- Create `.fxp` preset files for Serum from scratch.
- Set preset names and plugin-specific header information.
- Manage and manipulate raw preset data bytes.
- Future expansion planned for higher-level control over Serum parameters.

---

## Legal Notice

This project is an independent effort based on studying the `.fxp` file format structure through publicly available files and hex inspection. It **does not** use, incorporate, or rely on:

- Any proprietary source code from Xfer Records or Serum.
- Any copyrighted, decompiled, or leaked materials.

The `.fxp` file format itself originates from Steinberg's VST specification, with plugin-specific sections determined by Serum. This project provides tools to generate such files solely based on open observation of the format's structure.

---

## Usage

This project is currently designed as a C# library. Example usage:

```csharp
var preset = new SerumFxpPreset();
preset.Header.PresetName = "My Custom Preset";

// TODO: Populate preset.PresetData.RawData with valid Serum-compatible preset bytes

preset.Save("MyPreset.fxp");
```

---

## Disclaimer

Xfer Serum is a trademark of Xfer Records. This project is not affiliated with, endorsed by, or associated with Xfer Records or its products in any way.

Generated `.fxp` files may or may not load properly in Serum depending on the correctness of the preset data you provide. It is your responsibility to ensure generated presets are valid.

---

The file format documentation available in this project's wiki is a **work in progress** based solely on independent analysis of publicly available `.fxp` files.

You can view the current format documentation here:  
[https://github.com/potatoTeto/SerumPresetGenerator/wiki/Serum-.fxp-File-Format-Documentation](https://github.com/<repo>/wiki/Serum-.fxp-File-Format-Documentation)

No guarantees are made regarding its completeness or accuracy. This information is shared publicly to encourage collaboration and community contributions to better understand the format.

If you have findings or improvements, your input is welcome.

---

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.
