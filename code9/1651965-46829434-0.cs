    public class FooBar
    {
        public string foo;
        public string bar;
        public static implicit operator FooBar((string, string) init)
        {
            return new FooBar{ foo = init.Item1, bar = init.Item2 };
        }
    }
