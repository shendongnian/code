    var data = new StoredProcedureData();
    data.Header.SPName = "foo";
    if (data.Header.SPName == "foo")
    {
        Console.WriteLine("foo");
    }
    else
    {
        Console.WriteLine("oops");
    }
