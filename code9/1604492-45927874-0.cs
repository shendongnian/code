    Bitmap bmp = new Bitmap(w, h, PixelFormat.Format32bppRgb);
                
                Graphics g = Graphics.FromImage(bmp);
                Image newImage;
    
                    newImage = Properties.Resources.red_frame_03;
    using (Bitmap oldBmp = new Bitmap(newImage))
                using (Bitmap newBmp = new Bitmap(oldBmp))
                using (Bitmap targetBmp = newBmp.Clone(new Rectangle(0, 0, newBmp.Width, newBmp.Height), PixelFormat.Format16bppArgb1555))
    
                {
                    g.DrawImage(targetBmp, new Rectangle(100, 0, 350, 350));
                   
    
                }
