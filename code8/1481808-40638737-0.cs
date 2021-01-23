    using System.Drawing;
    using System.Drawing.Imaging;
    ...
    using (var bmp = (Bitmap)(Image.FromFile("input.bmp")))
    {
        var paletteCopy = bmp.Palette;
        // palette index 11 is bright yellow in the standard palette
        paletteCopy.Entries[11] = Color.FromArgb(255, 192, 0);
        bmp.Palette = paletteCopy;
        bmp.Save("output.bmp", ImageFormat.Bmp);
    }
  
