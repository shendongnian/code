    public static bool IsNull_exception(dynamic source)
    {
        var h = source.x;
        Console.WriteLine(object.ReferenceEquals(null, h));   // false
        Console.WriteLine(null == h);                         // false  
        Console.WriteLine(object.Equals(h, null));            // false
        Console.WriteLine(h == null);                         // true
    
        if (source.x?.y == null) return true;
        return false;
    }
