        public static class ExpressionExtensions
        {
              public static SyntaxTree ToSyntaxTree(this Expression expression)
              {
                    var expressionCode = expression.ToReadableString();
                    return CSharpSyntaxTree.ParseText(expressionCode);
              }
        }
