    public List<T> Deserialize<T>(string path)
    {
        IFormatter seri = new BinaryFormatter();
        Stream str = new FileStream(path, FileMode.Open, FileAccess.Read);
        List<T> Lista = (List<T>)(seri.Deserialize(str));
        str.Close();
        return Lista;
    }
