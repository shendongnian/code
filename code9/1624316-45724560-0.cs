    private void SaveFile(string _pathToGet, string _pathToSave)
    {
        FileStream fs = new FileStream();
        byte[] = GetFile(_pathToGet);
        fs.Write(data, 0, data.Length);
    }
    private byte[] GetFile(_path)
    {
        FileStream fs = null;
        fs = File.Open(_path, FileMode.Open, FileAccess.Read);
        byte[] data = new byte[fs.Length];
        fs.Read(data, 0, (int)fs.Length);
        fs.Close();
        return data;
    }
    
