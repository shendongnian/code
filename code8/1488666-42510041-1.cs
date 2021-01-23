    IEnumerable<INode> nodes = client.GetNodes();
    List<INode> folders = nodes.Where(n => n.Type == NodeType.Directory).ToList();
    INode myFolder = folders.FirstOrDefault(f => f.Name == "FolderName");
    IEnumerable<INode> folder = client.GetNodes(myFolder);
    List<INode> allFiles = folder.Where(n => n.Type == NodeType.File).ToList();
    INode myFile = allFiles.FirstOrDefault(f => f.Name == "FileName");
    mega.DownloadFile(myFile, "DownloadFileDirectory");
