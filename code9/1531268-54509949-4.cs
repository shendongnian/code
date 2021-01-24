    class Program
    {
        static void Main(string[] args)
        {
            List<SomeComplexObject> toAdd = new List<SomeComplexObject>() {
            new SomeComplexObject(1,"FooBar"),
            new SomeComplexObject(2,"FizzBang")
            };
            var dict = new Dictionary<int,SomeComplexObject>();
            dict.AddByKey(toAdd, item => item.Key);
        }
    }
