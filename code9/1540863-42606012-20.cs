    IMyTable<List<object>> xxx = new MyTable() { Surname = "b", Addresss = 1 };
    xxx.Name = "a";
    IMyTable<List<object>> yyy = new MyTable() { Surname = "d", Addresss = 2 };
    yyy.Name = "c";
    var repo = new List<IMyTable<List<object>>>() { xxx, yyy }.AsQueryable();
    var Test = new Test<List<object>>(repo);
    var generic = Test.GetSelection<List<object>>("c");
    var specific = Test.GetSelection<List<object>>("c",
                    (Expression<Func<IMyTable<List<object>>, List<object>>>) 
                        (x => new List<object>() { x.Name, ((MyTable)x).Addresss }));
    var specifc2Columns = specific
        .Select(rows => new { Name = rows[0], Address = rows[1] });
