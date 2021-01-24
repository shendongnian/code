    private static MemoryMappedFile LoadAssembly(string filename, out long length, out MemoryMappedFileAccess access)
    {
        // Setup parameters to pass in
        return MemoryMappedFile.CreateFromFile(filename, mode, mapName, length, access);
    }
