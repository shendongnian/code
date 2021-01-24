    public IEnumerable<MyType> GetFromRepository(Expression<Func<MyType, bool>> filter)
    {
        _myModelService.Get(filter)
                       .OrderByDescending(x => x.Date);
    }
    // later....
    Expression<Func<MyType, bool>> myFilter = x => x.myProperty == "someValue";
    GetFromRepository(myFilter);
