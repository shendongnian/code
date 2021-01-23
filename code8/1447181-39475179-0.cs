    // resizing and filter (grayscale)
    using (FileStream stream = File.OpenRead("foo.jpg"))
    using (FileStream output = File.OpenWrite("bar.jpg"))
    {
        Image image = new Image(stream);
        image.Resize(image.Width / 2, image.Height / 2)
             .Grayscale()
             .Save(output);
    }
