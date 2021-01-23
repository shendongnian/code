    private static XElement GetDirectoryXml(DirectoryInfo dir)
    {
        var info = new XElement("dir", new XAttribute("name", dir.Name));
        try
        {
            foreach (var file in dir.GetFiles()) //here is the exception
            {
                info.Add(new XElement("file", new XAttribute("name", file.Name)));
            }
            foreach (var subDir in dir.GetDirectories())
            {
                info.Add(GetDirectoryXml(subDir));
            }
        }
        catch (UnauthorizedAccessException)
        {
        }
        return info;
    }
