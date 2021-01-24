            public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
    		{
    			var methodInfo = _model.GetSymbolInfo(node).Symbol as IMethodSymbol;
    			if (methodInfo != null)
    			{
    				var containingType = methodInfo.ContainingType;
    				if (methodInfo.IsExtensionMethod)
    				{
    					// extension method
    					var exp = node.Expression as MemberAccessExpressionSyntax;
    					if (exp != null)
    					{
    						// new arguments
    						var newArguments = SyntaxFactory.ArgumentList();
    						newArguments = newArguments.AddArguments(SyntaxFactory.Argument(exp.Expression));
    						newArguments = newArguments.AddArguments(node.ArgumentList.Arguments.ToArray());
    						// new expression
    						var stack = new Stack<SimpleNameSyntax>();
    						stack.Push(exp.Name);
    						stack.Push(SyntaxFactory.IdentifierName(containingType.Name));
    						for (var s = containingType.ContainingNamespace; s != null; s = s.ContainingNamespace)
    						{
    							if (!s.IsGlobalNamespace && s.Name != "")
    								stack.Push(SyntaxFactory.IdentifierName(s.Name));
    						}
                            // build and return
    						if (stack.Count >= 2)
    						{
    							var newExp = SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, stack.Pop(), stack.Pop());
    							while (stack.Any())
    								newExp = SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, newExp, stack.Pop());
    							return node.WithExpression(newExp).WithArgumentList(newArguments);
    						}
    					}
    				}
    			}
    			return base.VisitInvocationExpression(node);
    		}
