    protected void BindGridview()
    {
        string strpath = @"e:\vs\tdscripts";
        DirectoryInfo di = new DirectoryInfo(strpath);
        foreach (var file in di.GetFiles("*", SearchOption.AllDirectories))
        {
            string content = File.ReadAllText(file.FullName, Encoding.Default);
            content = content.Replace("Table", file.Directory.Name);
            File.WriteAllText(file.FullName, content, Encoding.Default);
        }
    }
