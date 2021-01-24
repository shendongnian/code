    public static Expression<TestCase> Or(Expression<TestCase> exp1, Expression<TestCase> exp2)
            {
                var param = exp1.Parameters;
                
                ParameterExpression local = Expression.Parameter(typeof(TestResult), "local");
     
                BlockExpression block = Expression.Block(
                    new[] { local },
                    Expression.Assign(local, exp1.Body),
                    Expression.Condition(Expression.Property(local, nameof(TestResult.Pass)), exp2.Body, local));
     
                return Expression.Lambda<TestCase>(block, param);
            }
