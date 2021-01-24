    public class ParametersExtractorVisitor : ExpressionVisitor {
        public IList<ParameterExpression> ExtractedParameters { get; } = new List<ParameterExpression>();
        protected override Expression VisitParameter(ParameterExpression node) {
            ExtractedParameters.Add(node);
            return base.VisitParameter(node);
        }
    }
