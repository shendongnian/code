    List<object> a = new List<object>();
    List<string> aStrings = new List<string>();
    List<int> aInts = new List<int>();
    
    //insert objects in a
    
    foreach(object o in a)
    {
        if(o is string)
        {
           aStrings.Add(o as string);
        }
        else if(a is int)
        {
           aInts.Add(o as int);
        }
    }
