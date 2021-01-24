    if (open.ShowDialog())
    {
        var item = new ImageModel
        {
            Image = new BitmapImage(new Uri(open.FileName))
        };
        
        Images.Add(item);
        CurrentImage = item;
    }
