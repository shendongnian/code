    Dictionary<string, Image> images = new Dictionary<string,Image>();
    foreach (var child in container.Children)
    {
        if (child is Image)
        {
            images.Add(
                ((Image) child).Name,
                (Image) child);
        }
    }
   
