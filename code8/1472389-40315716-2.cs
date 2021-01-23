    var enumerator = getInt().GetEnumerator();
    while(enumerator.MoveNext())
    {
        var MyObject = enumerator.Current;
        Console.WriteLine(MyObject.Property);
    }
