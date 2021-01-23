    static int ComputerFailsOnTrue(bool flag)
    {
        if (flag)
            throw null;
        return 10;
    }
    static IEnumerable<Lazy<double>> foo()
    {
        yield return new Lazy<double>(()=>ComputerFailsOnTrue(true));
        yield return new Lazy<double>(()=>ComputerFailsOnTrue(false));
        yield return new Lazy<double>(()=>ComputerFailsOnTrue(false));
    }
    static public void Main()
    {
        foreach (var item in foo().Skip(1).Select(l=>l.Value))
        {
            Console.WriteLine($"Hey {item}");
        }
        Console.ReadLine();
    } 
