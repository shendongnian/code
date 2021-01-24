    private void Start()
    {
        dynamic this2 = this;
        var arr = new object[]
        {
        1, // int
        1L, // long
        "Hello World" // string
        };
        foreach (var dyn in arr.Cast<dynamic>())
        {
            this2.DoSomething(dyn);
        }
        Console.ReadKey();
    }
