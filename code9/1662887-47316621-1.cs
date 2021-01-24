    void Main() {  }
    
    static void Method1()
    {
        foreach (var x in g.GetList()) { }
    }
    
    static void Method2()
    {
        IEnumerable<object> list = g.GetList();
        foreach (var x in list) { }
    }
    
    static class g
    {
        public static IEnumerable<object> GetList() => new List<object>();
    }
