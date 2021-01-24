           UIElement element = LetterHeadGrid as UIElement;
            
            Size theTargetSize = new Size(260, 72);
            element.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
            element.Arrange(new Rect(theTargetSize));
            // to affect the changes in the UI, you must call this method at the end to apply the new changes
            element.UpdateLayout();
            double dpiScale = 600.0 / 96;
            double dpiX = 600.0;
            double dpiY = 600.0;
            RenderTargetBitmap rtb = new RenderTargetBitmap(Convert.ToInt32((theTargetSize.Width) * dpiScale), Convert.ToInt32((theTargetSize.Height) * dpiScale), dpiX, dpiY, PixelFormats.Pbgra32);
            element.Measure(theTargetSize);
            element.Arrange(new Rect(theTargetSize));
            rtb.Render(element);
            
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            string filePath = "LetterHead.png";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                using (Stream stm = File.Create(filePath))
                {
                    png.Save(stm);
                }
            }
            else
            {
                using (Stream stm = File.Create(filePath))
                {
                    png.Save(stm);
                }
            }
