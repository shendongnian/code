    private static void Main ()
    {
        var myList = Enumerable.Range (0, 100000000).ToList();
        var trueCopy = new List<int> (myList);
        var time = Environment.TickCount;
        var copyOne = myList.CreateCopyReflection().ToList();
        Console.WriteLine($"Reflection copy: {Environment.TickCount - time}");
        time = Environment.TickCount;
        var copyTwo = myList.CreateCopyLinq ().ToList();
        Console.WriteLine ($"Linq copy: {Environment.TickCount - time}");
        time = Environment.TickCount;
        var copyThree = myList.CreateCopyEnumeration ().ToList();
        Console.WriteLine ($"Enumeration copy: {Environment.TickCount - time}");
        time = Environment.TickCount;
        var copyFour = myList.CreateCopyCascade ();
        Console.WriteLine($"Cascade copy: {Environment.TickCount - time}");
        time = Environment.TickCount;
        Console.ReadLine ();
    }
    public static ICollection<T> CreateCopyReflection<T> (this ICollection<T> c)
    {
        var n = (ICollection<T>) Activator.CreateInstance (c.GetType());
        foreach (var item in c)
            n.Add (item);
        return n;
    }
    public static IEnumerable<T> CreateCopyLinq<T> (this IEnumerable<T> c) => c.Select (arg => arg);
    public static IEnumerable<T> CreateCopyEnumeration<T> (this IEnumerable<T> c)
    {
        foreach (var item in c)
            yield return item;
    }
    public static ICollection<T> CreateCopyCascade<T> (this ICollection<T> c)
    {
        if (c.GetType() == typeof(List<T>))
            return new List<T> (c);
        if (c.GetType() == typeof(HashSet<T>))
            return new HashSet<T> (c);
        //...
        return null;
    }
