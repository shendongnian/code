    /// <summary>
    /// Extract to specific file
    /// </summary>
    public static void WriteToFile(this RarArchiveEntry entry, string destinationFileName, ExtractOptions options = ExtractOptions.Overwrite)
    {
        entry.WriteToFile(destinationFileName, new NullRarExtractionListener(), options);
    }
