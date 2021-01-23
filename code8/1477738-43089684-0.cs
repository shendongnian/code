    public static class PredicateBuilder
    {
        public const bool TreatEntireExpressionAsAnd = true;
        public const bool TreatEntireExpressionAsOr = false;
        public static Expression<Func<T, bool>> Create<T>(bool value = TreatEntireExpressionAsAnd) { return param => value; }
        ...
