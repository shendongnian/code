    IMyTable<List<string>> xxx = new MyTable() { Surname = "b", Addresss = "1" };
    xxx.Name = "a";
    IMyTable<List<string>> yyy = new MyTable() { Surname = "d", Addresss = "2" };
    yyy.Name = "c";
    var repo = new List<IMyTable<List<string>>>() { xxx, yyy }.AsQueryable();
    var Test = new Test<List<string>>(repo);
    var tt = Test.GetSelection<List<string>>("c");
