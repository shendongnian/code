    public char[] GetArrayFromFile(string pathToFile)
    {
        using (StreamReader streamReader = new StreamReader(path1))
        {
            return streamReader.ReadToEnd().ToCharArray();
        }
    }    
    var arrayFromFile = GetArrayFromFile(@"..\path.file");
