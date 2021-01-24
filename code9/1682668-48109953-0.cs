    public static void Main(string[] args)
    {
        var repetitions = 1;
        var foo = new Foo();
        //warmup
        SetPropertyWithDynamic(foo, false); //JIT method without ca
        SetPropertyWithReflection(foo); //JIT method
        var watch = Stopwatch.StartNew();
        for (var i = 0; i < repetitions; i++)
        {
            SetPropertyWithDynamic(foo);
        }
        watch.Stop();
        Console.WriteLine($"Dynamic benchmark: {watch.ElapsedTicks}
        watch = Stopwatch.StartNew();
        for (var i = 0; i < repetitions; i++)
        {
            SetPropertyWithReflection(foo);
        }
        watch.Stop();
        Console.WriteLine($"Reflection benchmark: {watch.ElapsedTic
        Console.WriteLine(foo);
        Console.ReadLine();
    }
    static void SetPropertyWithDynamic(object o, bool runIt = true)
    {
        if (runIt)
        {
            ((dynamic)o).TheProperty = 1;
        }
    }
    static void SetPropertyWithReflection(object o)
    {
        o.GetType().GetProperty("TheProperty").SetValue(o, 1);
    }
    public class Foo
    {
        public int TheProperty { get; set; }
        public override string ToString() => $"Foo: {TheProperty}";
    }
