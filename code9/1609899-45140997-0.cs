    public object MyProperty { get; set; }
    public void DoSomething()
    {
        if(MyProperty is bool)
        {
            bool mp = MyProperty as bool;
            // do something with boolean type mp
        }
        else if(MyProperty is string)
        {
            string mp = MyProperty as string;
            // do something wit string type mp
        }
        // ....
    }
