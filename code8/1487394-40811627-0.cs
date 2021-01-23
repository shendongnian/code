    static class Extensions {
        public static TResult FakeInvoke<TResult, TExp>(this Func<TResult, TExp> instance, params object[] arguments) {
            // this is not intended to be called directly
            throw new NotImplementedException();
        }
        public static TExpression Unwrap<TExpression>(this TExpression exp) where TExpression : Expression {
            return (TExpression) new FakeInvokeVisitor().Visit(exp);
        }
        class FakeInvokeVisitor : ExpressionVisitor {
            protected override Expression VisitMethodCall(MethodCallExpression node) {
                // replace FakeInvoke call
                if (node.Method.Name == "FakeInvoke") {
                    var func = (Delegate) Expression.Lambda(node.Arguments[0]).Compile().DynamicInvoke();
                    var arguments = (object[]) Expression.Lambda(node.Arguments[1]).Compile().DynamicInvoke();
                    // your expression
                    var exp = (LambdaExpression) func.DynamicInvoke(arguments);
                    // it's body
                    return exp.Body;
                }
                return base.VisitMethodCall(node);
            }
        }
    }
