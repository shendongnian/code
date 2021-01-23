    /// <summary>
    /// Reads the file.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <param name="filename">The filename.</param>
    /// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
    public async Task<List<string>> ReadFile(StorageFolder folder, string filename) {
        StorageFile file = await folder.GetFileAsync(filename);
        IList<string> lines = await FileIO.ReadLinesAsync(file);
        return lines.ToList();
    }
