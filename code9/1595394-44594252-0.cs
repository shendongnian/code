    private static void Main(string[] args)
    {
        var a = new A();
        a.Property = Method1;
        Console.WriteLine(a.Property.Invoke());
        a.Property = Method2;
        Console.WriteLine(a.Property.Invoke());
        Func<string> oldMethod = a.Property;
        Console.WriteLine(oldMethod.Invoke());
        Console.ReadLine();
    }
    public class A
    {
        public Func<string> Property { get; set; }
    }
    private static string Method1()
    {
        return "Method1";
    }
    private static string Method2()
    {
        return "Method2";
    }
