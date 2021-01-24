    class WordExpressionModifier : System.Linq.Expression.ExpressionVisitor
    {
        public ExpressionTreeModifier(IQueryable<Word> allWords)
        {
            this.allWords = allWords;
        }
        private readonly IQueryable<Word> allWords;
        protected override Expression VisitConstant(ConstantExpression c)
        {
            // if the type of the constant expression is a WordCollection
            // return the same expression for allWords
            if (c.Type == typeof(WordCollection))
                return Expression.Constant(allWords);
            else
                return c;
		}
