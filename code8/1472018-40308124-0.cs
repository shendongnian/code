    public class A
    {
        public double? SomeValue { get; set; }
    }
    public static class Sample
    {
        public static void Go()
        {
            var a = new A();
            var accessor = ObjectAccessor.Create(a);
            accessor["SomeValue"] = 100.0; // succeeds
            accessor["SomeValue"] = 100M; // succeeds
            accessor["SomeValue"] = null; // succeeds
            accessor["SomeValue"] = 100; // throws, can't convert from int to decimal?
        }
    }
