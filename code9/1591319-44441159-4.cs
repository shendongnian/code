    using (var stream = new FileStream(tempFile, FileMode.Append))
    {
        //convertedImage = one byte array
        // All ints are 4-bytes
        stream.Write(BitConverter.GetBytes(convertedImage.Length), 0, 4);
        // now, we can write the buffer
        stream.Write(convertedImage, 0, convertedImage.Length);
    }
