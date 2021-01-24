      using System;
      using System.Text;
    
      interface IExpressionVisitor
      {
        void Visit(Literal literal);
        void Visit(Addition addition);
      }
    
      interface IExpression
      {
        void Accept(IExpressionVisitor visitor);
      }
    
      class Literal : IExpression
      {
        internal double Value { get; set; }
    
        public Literal(double value)
        {
          this.Value = value;
        }
        public void Accept(IExpressionVisitor visitor)
        {
          visitor.Visit(this);
        }
      }
