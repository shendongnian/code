    	public override void Initialize(AnalysisContext context)
		{
			context.RegisterSyntaxNodeAction(AnalyseSymbolNode, SyntaxKind.InvocationExpression);
		}
		private void AnalyseSymbolNode(SyntaxNodeAnalysisContext syntaxNodeAnalysisContext)
		{
			if (syntaxNodeAnalysisContext.Node is InvocationExpressionSyntax node)
			{
				if (syntaxNodeAnalysisContext
						.SemanticModel
						.GetSymbolInfo(node.Expression, syntaxNodeAnalysisContext.CancellationToken)
						.Symbol is IMethodSymbol methodSymbol)
				{
					if (node.Parent is ExpressionStatementSyntax)
					{
						// Only checks for the two most common awaitable types. In principle this should instead check all types that are awaitable
						if (EqualsType(methodSymbol.ReturnType, typeof(Task), typeof(ConfiguredTaskAwaitable)))
						{
							var diagnostic = Diagnostic.Create(Rule, node.GetLocation(), methodSymbol.ToDisplayString());
							syntaxNodeAnalysisContext.ReportDiagnostic(diagnostic);
						}
					}
				}
			}
		}
		/// <summary>
		/// Checks if the <paramref name="typeSymbol"/> is one of the types specified
		/// </summary>
		/// <param name="typeSymbol"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		/// <remarks>This method should probably be rewritten so it doesn't merely compare the names, but instead the actual type.</remarks>
		private static bool EqualsType(ITypeSymbol typeSymbol, params Type[] type)
		{
			var fullSymbolNameWithoutGeneric = $"{typeSymbol.ContainingNamespace.ToDisplayString()}.{typeSymbol.Name}";
			return type.Any(x => fullSymbolNameWithoutGeneric.Equals(x.FullName));
		}
