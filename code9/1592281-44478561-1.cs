    class EqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y) =>
            string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
        public int GetHashCode(string obj) => obj.ToUpper().GetHashCode();
    }
    ...
    
    Dictionary<string, Folder> allFolders = new Dictionary<string, Folder>(new EqualityComparer());
    using (System.IO.StreamReader stream = new System.IO.StreamReader(@"C:\\Read.txt"))
    {
        while (!stream.EndOfStream)
        {
            string[] folderInfo = stream.ReadLine().Split(' ');
            Folder folder = null;
            Folder subFolder = null;
            if (allFolders.TryGetValue(folderInfo[0], out folder))
            {
                subFolder = new Folder
                {
                    Name = folderInfo[1],
                    Size = Convert.ToInt64(folderInfo[2]),
                    Root = folder
                };
                folder.SubFolders.Add(subFolder.Name, subFolder);
                allFolders.Add(subFolder.Name, subFolder);
                continue;
            }
            folder = new Folder { Name = folderInfo[0] };
            subFolder = new Folder
            {
                Name = folderInfo[1],
                Size = Convert.ToInt64(folderInfo[2]),
                Root = folder
            };
            folder.SubFolders.Add(subFolder.Name, subFolder);
            allFolders.Add(subFolder.Name, subFolder);
            allFolders.Add(folder.Name, folder);
        }
    }
    foreach (var item in allFolders.Where(folder => folder.Value.Root == null))
    {
        Console.WriteLine($"{item.Value.Name} {item.Value.GetSum()}");
    }
