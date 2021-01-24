    using (var stream = new FileStream(tempFile, FileMode.Open))
    {
        // to catch the IO Exception when we have read them all
        try
        {
            // loop until IO error
            while (true)
            {
                byte[] convertedImage;
                // All ints are 4-bytes
                int size;
                byte[] sizeBytes = new byte[4];
                // Read size
                stream.Read(sizeBytes, 0, 4);
                // Convert to int
                size = BitConverter.ToInt32(sizeBytes, 0);
                // Allocate the buffer
                convertedImage = new byte[size];
                stream.Read(convertedImage, 0, size);
                // Do what you will with the array
                listOfArrays.Add(convertedImage);
            } // end while
        } catch (IOException)
        {
            // don't really need to do anything, but loading is done now
        }
    }
