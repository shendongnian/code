	class ReplaceParameter : ExpressionVisitor {
		private readonly Expression replacement;
		private readonly ParameterExpression parameter;
		public ReplaceParameter(
		    ParameterExpression parameter
    	,	Expression replacement
		) {
			this.replacement = replacement;
			this.parameter = parameter;
		}
		protected override Expression VisitParameter(ParameterExpression node) {
			return node == parameter ? replacement : node;
		}
	}
