    object[] RA = { "Ram", 123, 122 };
    foreach(var item in RA)
    {
        if (item is string)
        {
            Console.WriteLine("string");
        }
        else
        {
            Console.WriteLine("int");
        }
    }
