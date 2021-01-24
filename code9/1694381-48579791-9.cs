    Byte[] bytes = File.ReadAllBytes(OriginalFilepath);
    using (MemoryStream stream = new MemoryStream(bytes))
    using (Bitmap file = new Bitmap(stream))
    {
        PropertyItem propItem = file.PropertyItems[0];
        // Processing code
    }
