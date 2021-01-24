    // change terminaionDate to Expression<Func<MyEntity, DateTime>>
    static Expression<Func<MyEntity, bool>> GetFilterPredicate(Expression<Func<MyEntity, DateTime>> terminationDate) {
        // note Invoke
        Expression<Func<Error, bool>> filter = c => terminationDate.Invoke(c) <= DateTime.Now;
        // note Expand
        return filter.Expand();
    }
