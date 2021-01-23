    using System;
    using System.IO;
    internal class MyClass2
    {
        private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private Bitmap _bitmap = new Bitmap(_path + "\\" + "Bitmap.bmp");
    }
