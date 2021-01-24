    public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
            {
                var type = entry.DeclaringType;
                if (entry.DeclaringType != null)
                {
                    return new CodeCastExpression(typeof(string), new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(base.GetType()), "TranslateAndFill",
                        new CodePrimitiveExpression(entry.Expression.Trim())));
                }
                return new CodePrimitiveExpression((string)parsedData);
    
            }
