    List<Image> images = new List<Image>();
    ...
    using (var s = new System.IO.FileStream(imageFilePath, System.IO.FileMode.Open))
    {
        images.Add(Image.FromStream(s));
    }
