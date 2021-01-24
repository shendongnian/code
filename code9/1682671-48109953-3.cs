    public static void Main(string[] args)
    {
        var repetitions = 1;
        var warmup = true;
        var foo = new Foo();
        //warmup
        SetPropertyWithDynamic(foo, !warmup); //JIT method without caching the dynamic call
        SetPropertyWithReflection(foo); //JIT method
        //start up the runtime compiler
        var s = ((dynamic)"Hello").Substring(0, 2);
        for (var test = 0; test < 10; test++)
        {
            Console.WriteLine($"Test #{test}");
            var watch = Stopwatch.StartNew();
            for (var i = 0; i < repetitions; i++)
            {
                SetPropertyWithDynamic(foo);
            }
            watch.Stop();
            Console.WriteLine($"Dynamic benchmark: {watch.ElapsedTicks}");
            watch = Stopwatch.StartNew();
            for (var i = 0; i < repetitions; i++)
            {
                SetPropertyWithReflection(foo);
            }
            watch.Stop();
            Console.WriteLine($"Reflection benchmark: {watch.ElapsedTicks}");
        }
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
