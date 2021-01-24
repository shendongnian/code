    public struct MyClass
    {
        public int I => 42;
        public string S => "foo";
    }
    public static void Main()
    {
        var valueTypeProperty = typeof(MyClass).GetProperty("I");
        var referenceTypeProperty = typeof(MyClass).GetProperty("S");
        var lambdaValueTypeGetterDelegate = BuildUntypedGetter(valueTypeProperty);
        var lambdaReferenceTypeGetterDelegate = BuildUntypedGetter(referenceTypeProperty);
        var emitValueTypeGetterDelegate = EmitUntypedGetter(valueTypeProperty);
        var emitReferenceTypeGetterDelegate = EmitUntypedGetter(referenceTypeProperty);
        //warm-up - ensures that delegates are properly jitted
        lambdaValueTypeGetterDelegate(new MyClass());
        lambdaReferenceTypeGetterDelegate(new MyClass());
        emitValueTypeGetterDelegate(new MyClass());
        emitReferenceTypeGetterDelegate(new MyClass());
        TestDelegate("Compiled lambda (value type)     ", lambdaValueTypeGetterDelegate);
        TestDelegate("Compiled lambda (reference type) ", lambdaReferenceTypeGetterDelegate);
        TestDelegate("Emit (value type)                ", emitValueTypeGetterDelegate);
        TestDelegate("Emit (reference type)            ", emitReferenceTypeGetterDelegate);
        Console.ReadLine();
    }
    private static void TestDelegate(string description, Func<object, object> getterDelegate)
    {
        const long LOOPS_COUNT = 1_000_000_000;
        var obj = new MyClass();
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (long i = 0; i < LOOPS_COUNT; i++)
        {
            getterDelegate(obj);
        }
        sw.Stop();
        Console.WriteLine($"{description}: {sw.ElapsedMilliseconds} ms");
    }
