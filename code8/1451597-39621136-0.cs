        private static void GenerateDummyJpegAt(string outputPath, string nameToEmbed, int width, int height) {
            using (var bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb)) {
                BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
                byte[] noise = new byte[data.Width*data.Height*3];
                new Random().NextBytes(noise); // note that if you do that in a loop or from multiple threads - you may want to store this random in outside variable
                Marshal.Copy(noise, 0, data.Scan0, noise.Length);
                bmp.UnlockBits(data);
                using (var g = Graphics.FromImage(bmp)) {
                    // draw white rectangle in the middle
                    g.FillRectangle(Brushes.White, 0, height/2 - 20, width, 40);
                    var fmt = new StringFormat();
                    fmt.Alignment = StringAlignment.Center;
                    fmt.LineAlignment = StringAlignment.Center;
                    // draw text inside that rectangle
                    g.DrawString(nameToEmbed, SystemFonts.DefaultFont, Brushes.Black, new RectangleF(0, 0, bmp.Width, bmp.Height), fmt);
                }
                using (var fs = File.Create(outputPath)) {
                    bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
