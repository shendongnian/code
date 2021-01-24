    var repository = new GenericDataRepository<SomeType>(DbContextfactory);
    public void DbcontextFactory() 
    {
        return new _DbContext();
    }
