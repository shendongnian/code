    {
            string path = @"f:\temp\MyTest.tif";
            FileStream fs = new FileStream(path, FileMode.Create);
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)workspace.ActualWidth,
                (int)workspace.ActualHeight, 1 / 96, 1 / 96, PixelFormats.Pbgra32);
            bmp.Render(workspace);
            BitmapEncoder encoder = new TiffBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            encoder.Save(fs);
            fs.Close();
        }
