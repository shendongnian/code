    string imagesPath = @"C:\Path\To\Images";
    string labelsPath = @"C:\Path\To\Labels";
    using (BinaryReader brImages = new BinaryReader(new FileStream(imagesPath, FileMode.Open)), brLabels = new BinaryReader(new FileStream(labelsPath, FileMode.Open)))
    {
        int magic1 = brImages.ReadInt32Endian();
        if (magic1 != 2051)
            throw new Exception($"Invalid magic number {magic1}!");
        int numImages = brImages.ReadInt32Endian();
        int numRows = brImages.ReadInt32Endian();
        int numCols = brImages.ReadInt32Endian();
    
        Console.WriteLine($"Loading {numImages} images with {numRows} rows and {numCols} columns...");
    
        int magic2 = brLabels.ReadInt32Endian();
        if (magic2 != 2049)
            throw new Exception($"Invalid magic number {magic2}!");
        int numLabels = brLabels.ReadInt32Endian();
        if (numLabels != numImages)
            throw new Exception($"Number of labels ({numLabels}) does not equal number of images ({numImages})");
    
        byte[][] images = new byte[numImages][];
        byte[] labels = new byte[numLabels];
        int dimensions = numRows * numCols;
        for (int i = 0; i < numImages; i++)
        {
            images[i] = brImages.ReadBytes(dimensions);
            labels[i] = brLabels.ReadByte();
        }
    }
