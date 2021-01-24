    var methodSymbol = context.Symbol as IMethodSymbol;;
    var parameters = methodSymbol.Parameters;
    if (!parameters.SelectMany(p => p.GetAttributes()).Any(s => s.AttributeClass.Name == "ReadOnlyAttribute"))
    {
        // So you don't have params with ReadOnly attribute
        return;
    }
    // So you have params with ReadOnly attribute
    var location = methodSymbol.Locations.FirstOrDefault();
    if (location == null)
    {
        // throw or return 
    }
    // Can cahce CompilationRoot
    var methodNode = location.SourceTree.GetCompilationUnitRoot().FindNode(locati‌​on.SourceSpan);
    var childNodes = methodNode.ChildNodes().ToList();
    // Expression-bodied memeber
    var blockNode = childNodes.FirstOrDefault(s => s is BlockSyntax) ?? childNodes.FirstOrDefault(s => s is ArrowExpressionClauseSyntax);
    if (blockNode == null)
    {
        // throw or return 
    }
    // You can convert this linq to foreach and improve performance removing a where functions 
    // You can iterate descendant nodes for InvocationExpressionSyntax instead of blockNode. I think that it will faster 
    var invocationIdentifiers = blockNode.DescendantNodes()
        .Select(s => s as ArgumentSyntax)
        // !string.IsNullOrEmpty(s.RefOrOutKeyword.ValueText) – check that argument has 'ref' or 'out' keyword
        .Where(s => s != null && !string.IsNullOrEmpty(s.RefOrOutKeyword.ValueText))
        .SelectMany(s => s.Expression.DescendantNodesAndSelf())
        .Select(s => s as IdentifierNameSyntax)
        .Where(s => s != null)
        .Select(s => s.Identifier)
        .ToList();
        
    // You retrive all argument syntax with 'ref' and 'out' keyword from current block syntax and its descendant nodes
    // You only need to check if invocationIdentifiers contains your readonly parameter
    // For example, you can compare by name (you can use custom equality comparer)
    var names = invocationIdentifiers.ToLookup(s => s.ValueText, EqualityComparer<string>.Default);
    foreach (var parameter in parameters)
    {
        if (names.Contains(parameter.Name))
        {
            foreach (var token in names[parameter.Name])
            {
                // throw that readonly argument is a assignment
                context.ReportDiagnostic(Diagnostic.Create(rule, token.GetLocation()));
            }
        }
    }
