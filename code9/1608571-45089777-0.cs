    if(rootResult.data != null)
    {
        foreach (var computer in rootResult.data.computers)
        {
            Console.WriteLine(computer.ID);
            Console.WriteLine(computer.GUID);
           // etc for all properties
        }
    }
