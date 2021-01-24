    // makes nice round ellipse/circle images from rectangle images
            public Image ClipToCircle(Image srcImage, PointF center, float radius, Color backGround)
            {
                Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
                
                using (Graphics g = Graphics.FromImage(dstImage))
                {
                    RectangleF r = new RectangleF(center.X - radius, center.Y - radius,
                                                  radius * 2, radius * 2);
    
                    // enables smoothing of the edge of the circle (less pixelated)
                    g.SmoothingMode = SmoothingMode.AntiAlias;
    
                    // fills background color
                    using (Brush br = new SolidBrush(backGround))
                    {
                        g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
                    }
                    
                    // adds the new ellipse & draws the image again 
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(r);
                    g.SetClip(path);
                    g.DrawImage(srcImage, 0, 0);
                    return dstImage;
                }
            }
