    public static class Extensions_S
    {
        static Dictionary<Type, X> generators = new Dictionary<Type, X>();
        public static A generateA<T>(this T value)
        {
            X generator;
            if(!generators.TryGetValue(typeof(T), out generator)
            {
                generator = new X(typeof(T));
                generators.Add(typeof(T), generator);
            }
            return generator.from(value);
        }
    }
