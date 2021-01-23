    public struct Foo
    {
        public dynamic obj;
        public Foo(int val)
        {
            obj = new {
                bar = val
            };
        }
        public void WriteMyFooBar()
        {
            Console.WriteLine(obj.bar);
        }
    }
