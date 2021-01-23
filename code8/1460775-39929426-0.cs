    public static void Main(string[] args)
    {
        var a = new A();
       A.Type = typeof(B);
        var getB = (B)Activator.CreateInstance(a.Type);
        getB.F = "Say something ...";
    }
