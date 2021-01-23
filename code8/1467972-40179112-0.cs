    public class Foo<T>
    {
        public Dictionary<string, T> Bar;
    }
	Type[] types = typeof(Foo<>).GetField("Bar").FieldType.GetGenericArguments();
	Console.WriteLine("{0}\n{1}",
		types[0].IsGenericParameter,  // false, type is string
		types[1].IsGenericParameter   // true,  type is T
	);
