          public static Image CropToPath(Image srcImage, List<Point> Points, Pen p, Bitmap bmp)  
        {
            
            Bitmap mask = bmp;//new Bitmap(Bitmap.FromFile( (new DirectoryInfo(outPutPath)).GetFiles()?.OrderByDescending( f => f.CreationTimeUtc).First()?.FullName));
            
            DrawPoints(Graphics.FromImage(mask), p, Points);
            
          
            using (var imgattr = new ImageAttributes())
            {
                // set color key to Line 
                imgattr.SetColorKey(Color.Gainsboro, Color.Gainsboro);
                // Draw non-line portions of mask onto original
                using (var g3 = Graphics.FromImage(srcImage))
                {
                    SmoothGraphic(g3).DrawImage(
                        mask,
                        new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                        0, 0, srcImage.Width, srcImage.Height,
                        GraphicsUnit.Pixel, imgattr
                    );
                 
                    return srcImage;
                }
                
            }
            
        }
