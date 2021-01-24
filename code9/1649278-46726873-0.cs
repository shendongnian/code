    using (MagickImageCollection tiffPageCollection = new MagickImageCollection())
    {
        tiffPageCollection.Read("some.tif");
        foreach (MagickImage tiffPage in tiffPageCollection)
        {
            Density d = tiffPage.Density;
            int height = tiffPage.Height;
            int width = tiffPage.Width;
        }
    }
