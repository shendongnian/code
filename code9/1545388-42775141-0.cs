        private static bool IsWriteable(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Index:
                    PropertyInfo indexer = ((IndexExpression)expression).Indexer;
                    if (indexer == null || indexer.CanWrite)
                    {
                        return true;
                    }
                    break;
                case ExpressionType.MemberAccess:
                    MemberInfo member = ((MemberExpression)expression).Member;
                    PropertyInfo prop = member as PropertyInfo;
                    if (prop != null)
                    {
                        if (prop.CanWrite)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        Debug.Assert(member is FieldInfo);
                        FieldInfo field = (FieldInfo)member;
                        if (!(field.IsInitOnly || field.IsLiteral))
                        {
                            return true;
                        }
                    }
                    break;
            }
            return false;
        }
