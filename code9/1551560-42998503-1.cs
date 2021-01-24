    Nullable<bool> result = dlg.ShowDialog();
    if (result == true)
    {
        byte[] data;
        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(imagebox.Source as BitmapImage));
        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
        {
            encoder.Save(ms);
            data = ms.ToArray();
        }
        if (data != null)
        {
            string filename = dlg.FileName;
            System.IO.File.WriteAllBytes(filename, data);
        }
    }
