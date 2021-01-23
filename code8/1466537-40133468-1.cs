    /// <summary>
    /// Creates the file in a new folder.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <param name="newFolder">The new folder.</param>
    /// <param name="filename">The filename.</param>
    /// <param name="lineContent">Content of the line.</param>
    /// <returns>Task&lt;StorageFolder&gt;.</returns>
    public async Task<StorageFolder> CreateFileInANewFolder(
        StorageFolder folder, string newFolder, string filename, List<string> lineContent) {
        StorageFolder myFolder = await folder.CreateFolderAsync(newFolder);
        StorageFile file = await myFolder.CreateFileAsync(filename, 
                           CreationCollisionOption.ReplaceExisting);
        await FileIO.WriteLinesAsync(file, lineContent);
        return myFolder;
    }
