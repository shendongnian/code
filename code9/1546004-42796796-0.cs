    public object[] ConvertToArray()
    {
        object[] info = new object[data.Count];
        // Here's where I think the exception is raised
        for(int i = 0;i<data.Count;i++)
            info[i] = data[i];
        return info;
    }
