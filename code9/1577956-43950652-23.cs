    var enumerator = dict.GetEnumerator();
    try
    {
        while (enumerator.MoveNext())
        {
            var pair = enumerator.Current;
            myFunction(pair.Value);
        }
    }
    finally
    {
        enumerator.Dispose();
    }
