    static class Extensions {
        public static TResult FakeInvoke<TResult>(this Delegate instance, params object[] parameters)
        {
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
                    // first obtain reference to method being called (so, for c.FakeInvoke(...) that will be "c")
                    var func = (Delegate)Expression.Lambda(node.Arguments[0]).Compile().DynamicInvoke();
                    // explore method argument names and types
                    var argumentNames = new List<string>();
                    var dummyArguments = new List<object>();
                    foreach (var arg in func.Method.GetParameters()) {
                        argumentNames.Add(arg.Name);
                        // create default value for each argument
                        dummyArguments.Add(arg.ParameterType.IsValueType ? Activator.CreateInstance(arg.ParameterType) : null);
                    }
                    // now, invoke function with default arguments to obtain expression (for example, this one () => a*(a + 3)).
                    // all arguments will have default value (0 in this case), but they are not literal "0" but a reference to "a" member with value 0
                    var exp = (Expression) func.DynamicInvoke(dummyArguments.ToArray());
                    // this is expressions representing what we passed to FakeInvoke (for example expression (x + 3))
                    var argumentExpressions = (NewArrayExpression)node.Arguments[1];
                    // now invoke second visitor
                    exp = new InnerFakeInvokeVisitor(argumentExpressions, argumentNames.ToArray()).Visit(exp);
                    return ((LambdaExpression)exp).Body;
                }
                return base.VisitMethodCall(node);
            }
        }
        class InnerFakeInvokeVisitor : ExpressionVisitor {
            private readonly NewArrayExpression _args;
            private readonly string[] _argumentNames;
            public InnerFakeInvokeVisitor(NewArrayExpression args, string[] argumentNames) {
                _args =  args;
                _argumentNames = argumentNames;
            }
            protected override Expression VisitMember(MemberExpression node) {
                // if that is a reference to one of our arguments (for example, reference to "a")
                if (_argumentNames.Contains(node.Member.Name)) {
                    // find related expression
                    var idx = Array.IndexOf(_argumentNames, node.Member.Name);
                    var argument = _args.Expressions[idx];
                    var unary = argument as UnaryExpression;
                    // and replace it. So "a" is replaced with expression "x + 3"
                    return unary?.Operand ?? argument;
                }
                return base.VisitMember(node);
            }
        }
    }
