    [TestMethod]
    public void CallTableValuedFunction()
    {
        using (DbContext database = new DbContext())
        {
            IQueryable<IdModel> employees = database.ufnGetChildIds(new List<IdModel> { new IdModel { Id = 1 }});
        }
    }
