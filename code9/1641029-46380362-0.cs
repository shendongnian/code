    public T Load<T>(string path)
    {
        T obj = null;
        var bf = new BinaryFormatter();
        try
        {
            using (var file = File.Open(Application.persistentDataPath + path, FileMode.Open))
            {
                obj = (T)bf.Deserialize(file);
            }
        }
        catch(Exception exception)
        {
            // Log the exception
        }
        return obj;
        
    }
