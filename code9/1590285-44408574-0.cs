    public static string GetExpressionText<T>(Expression<Func<T, object>> expression)
    {
        bool needDot = false;
        Expression exp = expression.Body;
        string descr = string.Empty;
        while (exp != null)
        {
            if (exp.NodeType == ExpressionType.MemberAccess)
            {
                var ma = (MemberExpression)exp;
                descr = ma.Member.Name + (needDot ? "." : string.Empty) + descr;
                exp = ma.Expression;
                needDot = true;
            }
            else if (exp.NodeType == ExpressionType.ArrayIndex)
            {
                var be = (BinaryExpression)exp;
                descr = GetParameters(new ReadOnlyCollection<Expression>(new[] { be.Right })) + (needDot ? "." : string.Empty) + descr;
                exp = be.Left;
                needDot = false;
            }
            else if (exp.NodeType == ExpressionType.Index)
            {
                var ie = (IndexExpression)exp;
                descr = GetParameters(ie.Arguments) + (needDot ? "." : string.Empty) + descr;
                exp = ie.Object;
                needDot = false;
            }
            else if (exp.NodeType == ExpressionType.Parameter)
            {
                // It should be the "initial" x.
                break;
            }
            else if (exp.NodeType == ExpressionType.Call)
            {
                var ca = (MethodCallExpression)exp;
                if (ca.Method.IsSpecialName)
                {
                    bool isIndexer = ca.Method.DeclaringType.GetDefaultMembers().OfType<PropertyInfo>().Where(x => x.GetGetMethod() == ca.Method).Any();
                    if (!isIndexer)
                    {
                        throw new Exception();
                    }
                    descr = GetParameters(ca.Arguments) + (needDot ? "." : string.Empty) + descr;
                    exp = ca.Object;
                    needDot = false;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        return descr;
    }
    private static string GetParameters(ReadOnlyCollection<Expression> exps)
    {
        var values = new string[exps.Count];
        for (int i = 0; i < exps.Count; i++)
        {
            if (exps[i].NodeType != ExpressionType.Constant)
            {
                throw new Exception();
            }
            var ce = (ConstantExpression)exps[i];
            // Quite wrong here... We should escape string values (\n written as \n and so on)
            values[i] = ce.Value == null ? "null" :
                ce.Type == typeof(string) ? "\"" + ce.Value + "\"" :
                ce.Type == typeof(char) ? "'" + ce.Value + "\'" :
                ce.Value.ToString();
        }
        return "[" + string.Join(", ", values) + "]";
    }
