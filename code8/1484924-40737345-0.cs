    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo<string>();
            Expression<Func<string, int>> arg = s => s.Length;
            CallFindLast(foo, arg);
            Console.Read();
        }
        private static void CallFindLast(Foo<string> foo, object arg)
        {
            var dynamicArg = (dynamic)arg;
            foo.FindLast(dynamicArg);
        }
        private class Foo<T>
        {
            public T FindLast<TKey>(Expression<Func<T, TKey>> specification = null)
            {
                Console.WriteLine($"T: {typeof(T).Name}, TKey: {typeof(TKey).Name}");
                return default(T);
            }
        }
    }
