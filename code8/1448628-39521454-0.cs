    public void Test()
    {
        IList<object> data = new List<object>();
        ApplyFunc(x => MyFunc(x as IList<object>), data);
    }
