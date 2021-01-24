    public class ReplaceVisitor:ExpressionVisitor
    {
        private readonly Expression from, to;
        public ReplaceVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
    
        public override Expression Visit(Expression ex)
        {
            if(ex == from) return to;
            else return base.Visit(ex);
        }  
    }
    
    public static Expression Replace(this Expression ex,
        Expression from,
        Expression to)
    {
        return new ReplaceVisitor(from, to).Visit(ex);
    }
