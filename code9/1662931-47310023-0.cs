    [HttpPost]
    public object Post()
    {
        var result = new MyObject { Name = "test", Value = "test" };
        return result;
    }
