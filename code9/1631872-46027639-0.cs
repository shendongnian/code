    static void Main(string[] args)
    {
        var i = foo();
        WriteLine($"i: {i}");
    }
    static int foo()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        try
        {
            list.ForEach(each =>
            {
                if (each > 2)
                {
                    throw new LocalReturnException(each);
                }
                WriteLine(each);
            });
        }
        catch (LocalReturnException e)
        {
            return e.Value;
        }
        return 5;
    }
    class LocalReturnException : Exception
    {
        public int Value { get; }
        public LocalReturnException(int value)
        {
            Value = value;
        }
    }
