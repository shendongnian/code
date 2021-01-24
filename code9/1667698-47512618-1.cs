    var list = new List<Test> { 
        new Test {ID=1, Name =2, Type=3, 
            XML = new Dictionary<string,string>{{"Date","2017-09-01"}}},
        new Test {ID=10, Name =20, Type=30, 
            XML = new Dictionary<string,string>{{"Date","2017-01-01"}}},
        new Test {ID=100, Name =200, Type=300, 
            XML = new Dictionary<string,string>{{"Date","2017-03-01"}}},
            };
            
    list.Sort(Test.SortOn("Date"));
    
    list.Dump();
