    using System;
    using System.Drawing;
    namespace BitmapTest
    {
        class Program
        {
            private static Random _rand = new Random();
            private static void Main(string[] args)
            {
                Bitmap bit = new Bitmap(500, 500);
                for (int i = 0; i < 500; i++)
                {
                    for (int j = 0; j < 500; j++)
                    {
                        var val = (int)(_rand.NextDouble() * int.MaxValue);
                        var b = (val & 0x000000FF);
                        var g = (val & 0x0000FF00) >> 8;
                        var r = (val & 0x00FF0000) >> 16;
                        //var a = (val & 0xFF000000) >> 24; (this would get you the alpha)
                        bit.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                bit.Save(@"C:\Temp\img.bmp");
                bit.Dispose();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }
    }
