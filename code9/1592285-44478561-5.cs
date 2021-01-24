    class EqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y) =>
            string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
        public int GetHashCode(string obj) => obj.ToUpper().GetHashCode();
    }
    ...
    
    // You should modify code below for supporting fol->fol and "fol_1 fol_2 30 fol_1 fol_2 45"
    Dictionary<string, Folder> allFolders = new Dictionary<string, Folder>(new EqualityComparer());
    string[] folderInfo = null;
    using (System.IO.StreamReader stream = new System.IO.StreamReader(@"C:\\Read.txt"))
    {
        folderInfo = stream.ReadToEnd().Split(new[] { Environment.NewLine, " " }, StringSplitOptions.RemoveEmptyEntries);
    }
    for (int i = 0; i < folderInfo.Length; i += 3)
    {
        Folder folder = null;
        Folder subFolder = null;
        if (allFolders.TryGetValue(folderInfo[i], out folder))
        {
            subFolder = new Folder
            {
                Name = folderInfo[i + 1],
                Size = Convert.ToInt64(folderInfo[i + 2]),
                Root = folder
            };
            folder.SubFolders.Add(subFolder.Name, subFolder);
            allFolders.Add(subFolder.Name, subFolder);
            continue;
        }
        folder = new Folder { Name = folderInfo[i] };
        subFolder = new Folder
        {
            Name = folderInfo[i + 1],
            Size = Convert.ToInt64(folderInfo[i + 2]),
            Root = folder
        };
        
        folder.SubFolders.Add(subFolder.Name, subFolder);
        allFolders.Add(subFolder.Name, subFolder);
        allFolders.Add(folder.Name, folder);
    }
    foreach (var item in allFolders.Where(folder => folder.Value.Root == null))
    {
        Console.WriteLine($"{item.Value.Name} {item.Value.GetSum()}");
    }
