    private void AddFrameAndSave(Image photo, Image frame, string outputFilePath)
    {
            using (frame)
            {
                var width = 600; //Set the final image width. Usually it'll be photo.width
                var height = 450; //The same with height
                using (var bitmap = new Bitmap(width, height))
                {
                    using (var canvas = Graphics.FromImage(bitmap))
                    {
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        canvas.DrawImage(photo,
                            new Rectangle(0,
                                0,
                                width,
                                height),
                            new Rectangle(0,
                                0,
                                photo.Width,
                                photo.Height),
                            GraphicsUnit.Pixel);
                        canvas.DrawImage(frame, new Rectangle(0,
                            0,
                            width,
                            height), new Rectangle(0,
                            0,
                            frame.Width,
                            frame.Height), GraphicsUnit.Pixel);
                        canvas.Save();
                    }
                    
                    bitmap.Save(outputFilePath,ImageFormat.Jpeg);
                    
                }
            }
        }
