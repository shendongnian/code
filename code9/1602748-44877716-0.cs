    //Parameters class
    public Class Parameters
    {
        public List<string> A {get; set;}
        public List<int> B {get; set;}
    }
    //some function in a controller
    public List<SomeResult> GetResult(Parameters pars)
    {
        var db = new DbContext();
        var result = db.SomeResult.Where(s => s.Any(p =>p.SomeString == pars.A
                       || p.SomeInt == pars.B))
                .ToList();
        return result;
    }
