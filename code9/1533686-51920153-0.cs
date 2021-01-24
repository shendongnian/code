    [DbFunction("dbo","MyTableValuedFunction")]
    public virtual IQueryable<MyClass> MyFunction(string keyword)
    {
        var keywordsParam = new System.Data.Entity.Core.Objects.ObjectParameter("keywords", typeof(string))
        {
            Value = keyword
        };
    
        return (this as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext
            .CreateQuery<MyClass>("[Your DbContext Name].MyFunction(@keywords)", keywordsParam);
    }
