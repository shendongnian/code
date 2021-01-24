    private void Cap()
            {
                using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                                Screen.PrimaryScreen.Bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                    {
                        g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                         Screen.PrimaryScreen.Bounds.Y,
                                         0, 0,
                                         bmpScreenCapture.Size,
                                         CopyPixelOperation.SourceCopy);
                    }
    
                    Rectangle section = new Rectangle(new Point(this.Width, this.Height), bmpScreenCapture.Size);
                    Bitmap CroppedImage = CropImage(bmpScreenCapture, section);
                    CroppedImage.Save("c:\\temp\\screens\\1.bmp", ImageFormat.Bmp);
                }
    
            
          
           
            }
    
            public Bitmap CropImage(Bitmap source, Rectangle section)
            {
                // An empty bitmap which will hold the cropped image
                Bitmap bmp = new Bitmap(section.X, section.Y);
    
                Graphics g = Graphics.FromImage(bmp);
    
                // Draw the given area (section) of the source image
                // at location 0,0 on the empty bitmap (bmp)
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
    
                return bmp;
            }
