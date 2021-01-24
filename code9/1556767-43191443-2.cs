    using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
    {
        if (IsImage(stream))
        {
            allImages.Add(Image.FromFile(file));
        }
    }
    ...
    if (allImages.Count > 0)
    {
        byte[] data = imageListToByteArray(allImages);
        serverSendByteArray(data, 12);
    }
