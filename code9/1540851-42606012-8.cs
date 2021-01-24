    IMyTable<List<string>> xxx = new MyTable() { Surname = "b", Addresss = "1" };
    xxx.Name = "a";
    IMyTable<List<string>> yyy = new MyTable() { Surname = "d", Addresss = "2" };
    yyy.Name = "c";
    var repo = new List<IMyTable<List<string>>>() { xxx, yyy }.AsQueryable();
    var Test = new Test<List<string>>(repo);
    var generic = Test.GetSelection<List<string>>("c");
    var specific = Test.GetSelection<List<string>>("c",
                    (Expression<Func<IMyTable<List<string>>, List<string>>>) (x => new List<string>() { x.Name, ((MyTable)x).Addresss }));
