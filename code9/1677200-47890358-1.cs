    public class Foo { public int FooValue { get; set; } }
        
    public void ExpressionInArray()
    {
        var propertyReference = MemberExpression.Property(Expression.Constant(new Foo() { FooValue = 3 }), "FooValue");
        var validValues = Expression.Constant(new[] { 3, 4, 5 });
        var invalidValues = Expression.Constant(new[] { 6, 7, 8 });
        var expressionEvaluatingToTrue = propertyReference.In(validValues);
        var expressionEvaluatingToFalse = propertyReference.In(invalidValues);
        var expressionEvaluatingToTrue2 = propertyReference.NotIn(invalidValues);
        var expressionEvaluatingToFalse2 = propertyReference.NotIn(validValues);
    }
