    foreach(var item in classArray[1])
    {
        var typedItem = (ExcelSDRAddIn.UserControlSDR.Classification) item;
        Console.WriteLine($"Id {typedItem.Id} has names:");
        for (int i = 0; i < typedItem.Names.Count; i++)
        {
            Console.WriteLine($" - {typedItem.Names[i]}");
        }
    }
