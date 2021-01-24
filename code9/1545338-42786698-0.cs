     private void SaveMapFileAs_click(object sender, RoutedEventArgs e)
            {
    
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = ".bmp"; // Default file extension
                dlg.Filter = "BMP files (.bmp)|*.bmp"; // Filter files by extension
    
                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();
    
                // Process save file dialog box results
                if (result == true)
                {
                    string filename = dlg.FileName;
                    RenderTargetBitmap rtb = new RenderTargetBitmap((int)MainCanvas.RenderSize.Width,
                          (int)MainCanvas.RenderSize.Height, 96, 96, PixelFormats.Default);
    
                    VisualBrush sourceBrush = new VisualBrush(MainCanvas);
                    DrawingVisual drawingVisual = new DrawingVisual();
                    DrawingContext drawingContext = drawingVisual.RenderOpen();
                    using (drawingContext)
                    {
                        drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0),
                               new Point(MainCanvas.RenderSize.Width, MainCanvas.RenderSize.Height)));
                    }
    
                    rtb.Render(drawingVisual);
                    //endcode as BMP
                    BitmapEncoder bmpEncoder = new BmpBitmapEncoder();
                    bmpEncoder.Frames.Add(BitmapFrame.Create(rtb));
    
                    //save to memory stream
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    
                    bmpEncoder.Save(ms);
                    ms.Close();
                    System.IO.File.WriteAllBytes(filename, ms.ToArray());
                }
                
            }
