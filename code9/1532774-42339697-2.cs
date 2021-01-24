     TestClass tc = new TestClass { CatID = 1, NewsID = 1, SubCatID = 1, NewsDefaultFile = "test1", NewsHeader = "test2", NewsText = "test3", NewsTitle = "test4" };
            Mapper.Initialize(cfg => cfg.CreateMap<TestClass, NewTestClass>());
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TestClass, NewTestClass>());
            var mapper = new Mapper(config);
            NewTestClass ntx = Mapper.Map<NewTestClass>(tc);
            Console.WriteLine(ntx.NewsID);
