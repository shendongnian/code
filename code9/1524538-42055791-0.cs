    var tasks = Enumerable.Range(0, 250).Select(i => GetPages.CallHttp());
    var contents = await Task.WhenAll(tasks);
    foreach (var content in contents)
    {
        TestObject obj = content.ToTestObject(); //take the string and find some values in it. 
        Console.WriteLine(obj.H1Tag);
    }
