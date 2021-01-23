    public void TestIt()
    {
        var x = new MyClass { _answer = "gaga" };
        object obj = x.GetDate();
        if (obj == null) obj = x.GetInt();
        // etc
    }
