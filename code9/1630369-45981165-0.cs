      static void Main(string[] args)
            {
                var data = new [] 
                {
                    new TestClass{ A = "A" },
                    new TestClass{ A = "" },
                    new TestClass{ A = "" },
                    new TestClass{ A = "" },
                    new TestClass{ A = "" }
                };
    
                var queryData = data.AsQueryable();
    
                queryData = queryData.
                    Where(a => a.A == "A").OrderBy(a => a.A);
    
              
                Expression<Func<TestClass, bool>> filter = ( new  ExpressionGetter<Func<TestClass, bool>>()).GetWhere(queryData);
    
                Console.ReadLine();
            }
    
            public class ExpressionGetter<T> : ExpressionVisitor
            {
                private Expression<T> filter;
    
                protected override Expression VisitMethodCall(MethodCallExpression node)
                {
                    if (node.Method.Name == "Where")
                    {
                        var a = node.Arguments[1] as UnaryExpression;
                        filter = (Expression<T>)a.Operand;
    
                        return node;
                    }
                    else
                    {
                        return base.VisitMethodCall(node);
                    }
                }
    
                public Expression<T> GetWhere<TElement>(IQueryable<TElement> queryData) 
                {
                    filter = null;
    
                    this.Visit(queryData.Expression);
    
                    return filter;
                }
            }
