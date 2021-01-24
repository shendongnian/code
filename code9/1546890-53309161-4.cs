       [TestInitialize]
            public void Initialize()
            {
                ContextFactory = new TestContextFactory();
                _Context = ContextFactory.CreateNew();
                Repository = new NyDBRepository(ContextFactory);
            }
