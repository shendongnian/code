    static void Main(string[] args)
    {
        RootObject ro = new RootObject();
        Cells cs = new Cells();
        cs.results = new List<Result>();
        Result rt = new Result();
        rt.Key = "Title";
        rt.Value = "hello";
        rt.ValueType = "Edm.String";
        cs.results.Add(rt);
        Result rs = new Result();
        rs.Key = "Size";
        rs.Value = "3223";
        rs.ValueType = "Edm.Int64";
        cs.results.Add(rs);
        ro.Cells = cs;
        string json = JsonConvert.SerializeObject(ro);
    }
