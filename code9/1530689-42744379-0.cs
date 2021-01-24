    // here can be NullReferenceException
    var en = text.GetEnumerator();
    while(en.MoveNext())
    {
        var c = en.Current;
        {
            ...
        }
    }
