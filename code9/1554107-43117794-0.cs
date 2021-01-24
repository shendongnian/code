    public class BlockVariableRemover : ExpressionVisitor
    {
        private readonly Dictionary<Expression, Expression> replaces = new Dictionary<Expression, Expression>();
        public readonly Func<ParameterExpression, int, Expression> Replacer;
        public BlockVariableRemover(Func<ParameterExpression, int, Expression> replacer)
        {
            Replacer = replacer;
        }
        protected override Expression VisitBlock(BlockExpression node)
        {
            var removed = new List<Expression>();
            var variables = node.Variables.ToList();
            for (int i = 0; i < variables.Count; i++)
            {
                var variable = variables[i];
                var to = Replacer(variable, i);
                if (to != variable)
                {
                    removed.Add(variable);
                    replaces.Add(variable, to);
                    variables.RemoveAt(i);
                    i--;
                }
            }
            if (removed.Count == 0)
            {
                return base.VisitBlock(node);
            }
            var expressions = node.Expressions.ToArray();
            for (int i = 0; i < expressions.Length; i++)
            {
                expressions[i] = Visit(expressions[i]);
            }
            foreach (var rem in removed)
            {
                replaces.Remove(rem);
            }
            return Expression.Block(variables, expressions);
        }
        public override Expression Visit(Expression node)
        {
            Expression to;
            if (node != null && replaces.TryGetValue(node, out to))
            {
                return base.Visit(to);
            }
            return base.Visit(node);
        }
    }
