    var array = new[] { 1, 2 };
    
                Expression<Func<A, bool>> exp = x => array.Contains(x.Id);
                Expression<Func<A, bool>> exp2 = x => x.Id == 1 || x.Id == 2;
    
    
                var p1 = Expression.Parameter(typeof(A));
                
                var exp3 = Expression.Lambda<Func<A, bool>>(ExpressionVisitor.Visit(new []{ exp.Body }.ToList().AsReadOnly(), (m) => {
                    if (m.NodeType == ExpressionType.Call)
                    {
                        var method = (MethodCallExpression)m;
                        if (method.Method.Name == "Contains" && method.Arguments.Count == 2)
                        {
                            var items = Expression.Lambda<Func<object>>(method.Arguments[0]).Compile()();
                            var prop = ((MemberExpression)method.Arguments[1]);
                            return ((IEnumerable<int>)items).Select(i => Expression.Equal(Expression.Property(prop.Expression, prop.Member.Name), Expression.Constant(i))).Aggregate((a, i) => a == null ? i : Expression.OrElse(a, i));
                        }
                    }
                    return m;
                })[0],exp.Parameters);
    
    
                var func = exp3.Compile();
                
                Console.WriteLine(func(new A { Id = 1 }));
                Console.WriteLine(func(new A { Id = 2 }));
                Console.WriteLine(func(new A { Id = 3 }));
