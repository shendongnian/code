    public IEnumerable<TestUser> Getdata()
    {
        // Code here
        return dt.AsEnumerable().Select(x => new TestUser{
                                  someId = x.Field<string>("id"),
                                 // like wise initialize properties here
                                 });
    }
