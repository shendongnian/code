    using Foo;
    using static Foo.List;
    
    public void Example()
    {
        var test = new Test(); 
        //Because of "using static Foo.List;" you don't need to use "List.active"
        string a = test.get("foo", active);
        string b = test.get("foo", all);
    }
