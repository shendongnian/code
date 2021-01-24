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
