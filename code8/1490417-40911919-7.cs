    public void TestIt()
    {
        var x = new MyClass { _answer = "gaga" };
        var obj = (object) x.GetDate() ?? x.GetInt() /* ?? [etc] */ ;
    }
