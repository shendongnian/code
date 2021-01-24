    private static ConditionalExpression ExpressionA(int num)
            {
                 return Expression.Condition(
                              Expression.Constant(num > 10),
                              Expression.Constant("num is greater than 10"),
                              Expression.Constant("num is smaller than 10")
                            );
            }
