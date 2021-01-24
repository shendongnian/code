    public static void Test()
    {
        List<object> list = new List<object>();
        list.AddRange(Customers);
        list.AddRange(Employees);
        list.AddRange(Items);
    
        OutputFile(list);
    }
    public static void OutputFile(List<object> myInput)
    {
        foreach (dynamic someGenericObject in myInput)
        {
            //...
        }
    }
