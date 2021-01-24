    private readonly object _sync = new object();
    
    // ...
    
    
    lock( _sync )
    {
        if( _dictionary.ContainsKey(someKey) == false )
        {
             _dictionary.Add(someKey, somevalue);
        }
    }
