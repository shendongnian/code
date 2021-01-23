    public static void Detach<TObject>(TObject parentObj, params Expression<Func<TObject, object>>[] detachEntities)
            {
                foreach (var detachEntity in detachEntities)
                {
                    var methodCallExpression = detachEntity.Body as MethodCallExpression;
                    var member = methodCallExpression?.Arguments[0] as MemberExpression;
                    PropertyInfo prop;
                    if (member != null)
                    {
                        prop = (PropertyInfo)member.Member;
                        prop.SetValue(parentObj, null);
                    }
    
                    var memberExpression = detachEntity.Body as MemberExpression;
                    var expression = memberExpression?.Expression as MemberExpression;                
    
                    switch (memberExpression?.Expression.NodeType)
                    {
                        case ExpressionType.Parameter:
                            prop = (PropertyInfo)memberExpression.Member;
                            prop.SetValue(parentObj, null);
                            break;
                        case ExpressionType.MemberAccess:
                            if (expression != null)
                            {
                                prop = (PropertyInfo)expression.Member;
                                prop.SetValue(parentObj, null);
                            }
                            break;
                    }               
                }
            }
