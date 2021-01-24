    private class TestCalss
    {
        public int Id { get; set; }
    }
    private class SwapVisitor : ExpressionVisitor
    {
        public readonly Expression _from;
        public readonly Expression _to;
        public SwapVisitor(Expression from, Expression to)
        {
            _from = from;
            _to = to;
        }
        public override Expression Visit(Expression node) => node == _from ? _to : base.Visit(node);
    }
    private BinaryExpression Combine<T, TResult>(string op, Expression<Func<T, TResult>> left, Expression right, ParameterExpression parameter)
    {
        // Need to use parameter from outer lambda expression for equality two expressions 
        var swap = new SwapVisitor(left.Parameters[0], parameter);
        var newLeft = swap.Visit(left) as Expression<Func<T, TResult>>;
        switch (op)
        {
            case "=":
                return Expression.Equal(newLeft.Body, right);
            case "<":
                return Expression.LessThan(newLeft.Body, right);
            case ">":
                return Expression.GreaterThan(newLeft.Body, right);
        }
        return null;
    }
    ...
    var parameter = Expression.Parameter(typeof(TestCalss));
    var predicate = Expression.Lambda<Func<TestCalss, bool>>(
        Combine<TestCalss, int>("=", c => c.Id, Expression.Constant(156), parameter),
        parameter);
    var test = new TestCalss { Id = 156 };
    var result = predicate.Compile()(test); // <- true
