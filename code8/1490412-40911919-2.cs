    public void TestIt()
    {
        var x = new MyClass { _answer = "gaga" };
        var obj = x.GetDate();
        if (obj == null) obj = x.GetInt();
        // etc
    }
