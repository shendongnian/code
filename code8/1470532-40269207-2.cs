    public class Folder
    {
        public string Path { set; get; }
        public List<string> Files { set; get; }
        public List<Folder> SubFolders { set; get; }
    }
    Folder GetFolderHierarchy(string root)
    {
        var folder = new Folder();
        var dir = new DirectoryInfo(root);
        folder.Path = root;
        folder.Files =  dir.GetFiles().Select(x => x.FullName).ToList();
        folder.SubFolders = dir.GetDirectories().Select(x => GetFolderHierarchy(x.FullName))
                            .ToList();
        return folder;
    }
