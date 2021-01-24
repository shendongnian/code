    public static void Main(string[] args)
    {
        string name = Console.ReadLine();
        // The second true will ignore case
        var cls = Type.GetType("Animals." + name, true, true);
        var @object = Activator.CreateInstance(cls);
    }
