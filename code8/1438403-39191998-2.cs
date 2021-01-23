    // Convert the text into bytes
    byte[] DataBytes = ASCIIEncoding.ASCII.GetBytes(OriginalText);
    
    // Compress it
    byte[] Compressed = SevenZip.Compression.LZMA.SevenZipHelper.Compress(DataBytes);
    
    // Decompress it
    byte[] Decompressed = SevenZip.Compression.LZMA.SevenZipHelper.Decompress(Compressed);
