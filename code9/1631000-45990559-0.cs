    void DumpProperties(IInput o)
    {
        var t = o.GetType();
        var props = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var prop in props)
        {
            Console.WriteLine(String.Format("Name: {0} Value: {1}",
                prop.Name,
                prop.GetValue(o).ToString()
            );
        }
    }     
