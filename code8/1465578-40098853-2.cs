    using System;
    using System.Drawing;
    using System.IO;
    internal class MyClass3
    {
        private Bitmap _bitmap =
            new Bitmap(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Bitmap.bmp"));
    }
