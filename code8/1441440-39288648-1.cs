    static void foo(ref int? val)
    {
        if (val != null)
        {
            --val;
        }
    }
    
    static void Main(string[] args)
    {
        int? val = 5;
        foo(ref val);
    }
