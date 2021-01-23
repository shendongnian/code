    static int compute(bool flag)
    {
        if (flag)
            throw null;
        return 10;
    }
    static IEnumerable<Lazy<double>> foo()
    {
        yield return new Lazy<double>(()=>compute(true));
        yield return new Lazy<double>(()=>compute(false));
        yield return new Lazy<double>(()=>compute(false));;
    }
    static public void Main()
    {
        foreach (var item in foo().Skip(1).Select(l=>l.Value))
        {
            Console.WriteLine($"Hey {item}");
        }
        Console.ReadLine();
    } 
