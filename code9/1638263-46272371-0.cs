    public void GetData(object obj)
    {
        foreach(var item in obj.GetType().GetProperties())
        {
             Console.WriteLine(item.Name + ":\t" + item.GetValue(obj));
        }
    } 
