    using (var stream = new FileStream(tempFile, FileMode.Open))
    {
        byte[] convertedImage;
        // All ints are 4-bytes
        int size;
        byte[] sizeBytes = new byte[4];
        stream.Read(sizeBytes, 0, 4);
        size = BitConverter.ToInt32(sizeBytes, 0);
        convertedImage = new byte[size];
        stream.Read(convertedImage, 0, size);
    }
