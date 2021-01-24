    public string SearchNestedDirectory(string path, string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("name");
    
        return SearchNestedDirectoryImpl(path, name);
    }
    private string SearchNestedDirectoryImpl(string path, string name, int depth = 1)
    {
        if (depth > name.Length)
            return null;
    
        var result = Directory.GetDirectories(path, name.Substring(0, depth)).FirstOrDefault();
        if (result == null)
            return null;
        
        if (Path.GetDirectoryName(result) == name)
            return result;
        
        return SearchNestedDirectoryImpl(result, name, depth + 1);
    }
