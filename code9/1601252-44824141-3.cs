    await Task.Run(() => 
    { 
        using (var filestream = new FileStream(GetImageLocation(), FileMode.Create))
        {      
             BitmapImage image = new BitmapImage(new Uri(oldImagePath));
             var encoder = new JpegBitmapEncoder() { QualityLevel = 17 };
             encoder.Frames.Add(BitmapFrame.Create(image));
             encoder.Save(filestream);
        }
    }
