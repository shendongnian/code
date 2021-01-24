    BitmapImage image = new BitmapImage(new Uri(oldImagePath));
    var encoder = new JpegBitmapEncoder() { QualityLevel = 17 };
    encoder.Frames.Add(BitmapFrame.Create(image));
    using (var mem = new MemoryStream())
    using (var filestream = new FileStream(GetImageLocation(), FileMode.Create))
    {
        encoder.Save(mem);
        var data = mem.ToArray();
        await filestream.WriteAsync(date, 0, data.Length);
    }
