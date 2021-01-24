    [TestMethod]
    public async Task Test() {
        ContextUtils.DbContext = new SomeDbContext();
        using (ContextUtils.DbContext) {
            await DoSomeActions();
        }
    }
