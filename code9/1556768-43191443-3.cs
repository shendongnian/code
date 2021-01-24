    using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
    {
        if (IsImage(stream))
        {
            allImages.Add(Image.FromFile(file));
        }
        stream.Close();
    }
    ....
    if (allImages.Count > 0)
    {
        byte[] data = imageListToByteArray(allImages);
        foreach(Image img in allImages)
        {
            img.Dispose();
        }
        serverSendByteArray(data, 12);
    }                    
