    public class ConvertVisitor : ExpressionVisitor
    {
        private ParameterExpression Parameter;
        public Visitante(ParameterExpression parameter)
        {
            Parameter = parameter;
        }
        protected override Expression VisitParameter(ParameterExpression item)
        {
            // we just check the parameter to return the new value for them
            if(!item.Name.Equals(Parameter.Name))
                return item;
            return Parameter;
        }
     }
