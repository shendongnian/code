    class C
    {
        public void Method(int x)
        {
            Console.WriteLine("Method");
        }
    }
    static int GetSomeValue()
    {
        Console.WriteLine("GetSomeValue");
        return 0;
    }
    C c = null;
    c?.Method(GetSomeValue());
