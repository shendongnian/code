    public char[] GetArrayFromFile(string pathToFile)
    {
        using (StreamReader streamReader = new StreamReader(path1))
        {
            var data = streamReader.ReadToEnd();
        }
        return data.ToCharArray();
    }    
    var arrayFromFile = GetArrayFromFile(@"..\path.file");
