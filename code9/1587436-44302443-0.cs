    var listClass1 = context.Table1
        .Join(context.Table2,
            t1 => t1.Id,
            t2 => t2.Table1Id,
            (t1, t2) => new { t1, t2 })
        .Where(/*some expressions here*/)
        .Select(x => new Class1
            {
                prop1 = x.t1.Column1,
                prop2 = x.t2.Column2,
                prop3 = x.t1.Column3
            });
