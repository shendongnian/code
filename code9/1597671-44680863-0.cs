    // first get Build static field (it's not a property by the way)
    var buildProp = typeof(Matrix<>).MakeGenericType(ContentType)
                   .GetField("Build", BindingFlags.Public | BindingFlags.Static);
    // then get Dense method reference
    var dense = typeof(MatrixBuilder<>).MakeGenericType(ContentType)
                   .GetMethod("Dense", new[] { typeof(int), typeof(int) });
    // now construct expression call
    var call = Expression.Call(
                   Expression.Field(null /* because static */, buildProp), 
                   dense, 
                   Expression.Constant(Rows), 
                   Expression.Constant(Columns));
