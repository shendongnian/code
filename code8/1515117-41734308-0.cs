    public struct Foo
    {
        public dynamic obj;
        public Foo(int val)
        {
            obj = new
            {
                bar = val
            };
            Console.WriteLine(obj.bar); // Can't access bar.
        }
    }
