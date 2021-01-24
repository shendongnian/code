     private void Cap()
        {
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                  
                    g.CopyFromScreen(this.Location.X,
                                   this.Location.Y,
                                   0, 0,
                                   this.Size,
                                   CopyPixelOperation.SourceCopy);
     
                }
                Rectangle section = new Rectangle(new Point(this.Location.X, this.Location.Y), new Size(this.Width, this.Height));
                Bitmap CroppedImage = CropImage(bmpScreenCapture, section);
                CroppedImage.Save("c:\\temp\\screens\1.bmp", ImageFormat.Bmp);
                
            }
        
      
       
        }
        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics g = Graphics.FromImage(bmp);
            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
            return bmp;
        }
