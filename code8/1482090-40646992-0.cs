    private List<Func<int, string>> delegateList = new List<Func<int,string>>();
    public string Foo(int x)
    {
        return $"Foo {x}";
    }
    public string Bar(int x)
    {
        return $"Bar {x*2}";
    }
    public void Test()
    {
        delegateList.Add(Foo);
        delegateList.Add(Bar);
        delegateList.Add(x => $"Lambda {x*3}"); 
        foreach (var del in delegateList)
        {
            Console.WriteLine(del(23));
        }
    }
