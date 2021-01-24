    var list = new List<Table1>()
    {
        new Table1(){ Column1="x", Column2="y", Column3= "z"},
        new Table1(){ Column1="x", Column2="y", Column3= "t"},
        new Table1(){ Column1="a", Column2="b", Column3= "c"},
    };
    var resulut = list.GroupBy(x => new { C1 = x.Column1, C2 = x.Column2 })
                      .Select(g => g.FirstOrDefault());
