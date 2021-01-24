        public static byte[] CropImage(byte[] imgBytes, Rectangle rec)
        {
            byte[] result = null;
            using (MemoryStream mStream = new MemoryStream(imgBytes))
            {
                Image img = Image.FromStream(mStream);
                Bitmap croppedBmpImage = new Bitmap(200, 200);
                using (Graphics graphics = Graphics.FromImage(croppedBmpImage))
                {
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(img, new Rectangle(0, 0, 200, 200),
                        rec,
                        GraphicsUnit.Pixel);
                }
                ImageConverter converter = new ImageConverter();
                result = (byte[])converter.ConvertTo(croppedBmpImage, typeof(byte[]));
                using (MemoryStream jpegStream = new MemoryStream(result))
                {
                    croppedBmpImage.Save(jpegStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Image img1 = Image.FromStream(jpegStream);
                    img1.Save(@"C:\Users\darellis\Desktop\image1.jpg");
                }
                croppedBmpImage.Dispose();
            }
            return result;
        }
