    public void CopyFiles(string sourcePath)
    {
        string destination = "myshare2";
        string source = sourcePath.Replace("myshare1","");
        if (!System.IO.Directory.Exists($"{destination}{source}"))
        {
            System.IO.Directory.CreateDirectory($"{destination}{source}");
            System.IO.File.Copy(sourcePath, $"{destination}{source}", true);
        }     
    }
