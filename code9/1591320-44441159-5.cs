    using (var stream = new FileStream(tempFile, FileMode.Open))
    {
        // loop until we can't read any more
        while (true)
        {
            byte[] convertedImage;
            // All ints are 4-bytes
            int size;
            byte[] sizeBytes = new byte[4];
            // Read size
            int numRead = stream.Read(sizeBytes, 0, 4);
            if (numRead <= 0) {
                break;
            }
            // Convert to int
            size = BitConverter.ToInt32(sizeBytes, 0);
            // Allocate the buffer
            convertedImage = new byte[size];
            stream.Read(convertedImage, 0, size);
            // Do what you will with the array
            listOfArrays.Add(convertedImage);
        } // end while
    }
