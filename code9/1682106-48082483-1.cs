    public Expression<Func<MyWrapper, bool>> Convert(Expression<Func<MyClass, bool>> predicate)
    {
        var originalParameter = predicate.Parameters[0];
        var newParameter = Expression.Parameter(typeof(MyWrapper));
        var ma = Expression.Property(newParameter, nameof(MyWrapper.MyClass));
        var converter = new ConverterVisitor(originalParameter, ma);
        var newBody = converter.Visit(predicate.Body);
        return Expression.Lambda<Func<MyWrapper, bool>>(newBody, newParameter);
    }  
