    /// <summary>
    /// <see cref="ExpressionVisitor"/> to replace parameters with actual expressions.
    /// </summary>
    public sealed class ParameterReplaceVisitor : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, Expression> _replacements;
        /// <summary>
        /// Init with parameters and their replacements.
        /// </summary>
        public ParameterReplaceVisitor(IEnumerable<KeyValuePair<ParameterExpression, Expression>> replacements)
        {
            _replacements = replacements.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            Expression replacement;
            return _replacements.TryGetValue(node, out replacement) ? replacement : node;
        }
    }
