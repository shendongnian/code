    static void Main(string[] args)
    {
        var sourceFile=  new FileInfo(@"C:\Users\Micky\Downloads\20180112.zip");
        int length = (int) sourceFile.Length;  // length of target file
    
        // Create the memory-mapped file.
        using (var mmf = MemoryMappedFile.CreateFromFile(sourceFile.FullName,
                                                         FileMode.Open, 
                                                         "ImgA"))
        {
            var buffer = new byte[length]; // allocate a buffer with the same size as the file
    
            using (var accessor = mmf.CreateViewAccessor())
            {
                var read=accessor.ReadArray(0, buffer, 0, length); // read the whole thing
            }
    
            // let's try searching for a known byte sequence.  Change this to suit your file
            var target = new byte[] {71, 213, 62, 204,231};
    
            var foundAt = IndexOf(buffer, target);
    
        }
    }
