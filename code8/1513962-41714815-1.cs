      public static Expression<Func<OutT, bool>> ConvertTypeExpression<inT, OutT>(Expression expression) where OutT : class {
    
                var param = Expression.Parameter(typeof(OutT), "x");
    
                var result = new CustomExpVisitor<OutT>(param).Visit(expression); 
    
                Expression<Func<OutT, bool>> lambda = Expression.Lambda<Func<OutT, bool>>(result, new[] { param });
    
                return lambda;
            }
       private class CustomExpVisitor<T> : ExpressionVisitor {
                ParameterExpression _param;
    
                public CustomExpVisitor(ParameterExpression param) {
                    _param = param;
                }
    
                protected override Expression VisitParameter(ParameterExpression node) {
                    return _param;
                }
    
                protected override Expression VisitMember(MemberExpression node) {
                    if (node.Member.MemberType == MemberTypes.Property) {
                        MemberExpression memberExpression = null;
    
                        var memberName = node.Member.Name;
                        var otherMember = typeof(T).GetProperty(memberName);
    
                        memberExpression = Expression.Property(Visit(node.Expression), otherMember);
    
                        return memberExpression;
                    } else {
                        return base.VisitMember(node);
                    }
                }
            }
