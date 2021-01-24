    public Image ImageSrc
    {
        get
        {
            MemoryStream ms = new MemoryStream(GetImageAsByteArray());
            Image img = Image.FromStream(ms);
            YourCommandProperty.Execute(null);
            return img;
        }
    }
