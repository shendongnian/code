    using System;
    using System.Drawing;
    internal class MyClass1
    {
        private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private Bitmap _bitmap = new Bitmap(_path + "\\" + "Bitmap.bmp");
    }
