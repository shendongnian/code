    private void SaveImage(Canvas canvas, string fileName)
    {
        SaveFileDialog s = new SaveFileDialog();
        s.FileName = "Pic";
        s.DefaultExt = ".png";
        s.Filter = "Picture files (.png)|*.png";
        Nullable<bool> result = s.ShowDialog();
        if (result == true)
        {
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(4646, 3890, 1500d, 1500d, PixelFormats.Pbgra32);
            canvas.Measure(new Size((int)canvas.Width, (int)canvas.Height));
            canvas.Arrange(new Rect(new Size((int)canvas.Width, (int)canvas.Height)));
            renderBitmap.Render(canvas);
            string filename = s.FileName;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }
    }
