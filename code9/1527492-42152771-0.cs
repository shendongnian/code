    String[] allfiles = System.IO.Directory.GetFiles("myPath", "*.*", System.IO.SearchOption.AllDirectories);
    foreach (string file in allfiles)
    {
        newFile.CreateEntryFromFile(file);
    }
