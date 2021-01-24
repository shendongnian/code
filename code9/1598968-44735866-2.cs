    ...
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
    var blockNode = methodNode.ChildNodes().FirstOrDefault(s => s is BlockSyntax);
    if (blockNode == null)
    {
        // throw or return 
    }
    // You can convert this linq to foreach and improve performance removing a where functions 
    var assignmentIndetifiers = blockNode.DescendantNodes()
        .Select(s => s as AssignmentExpressionSyntax)
        .Where(s => s != null)
        .Select(s => s.Left as IdentifierNameSyntax)
        .Where(s => s != null)
        .Select(s => s.Identifier)
        .ToList();
        
    // You retrive all left identifiers in assignment expressions from current block syntax and its descendant nodes
    // You only need to check if assignmentIdentifiers contains your readonly parameter
    // For example, you can compare by name (you can use custom equality comparer)
    var names = assignmentIndetifiers.ToDictionary(s => s.ValueText, EqualityComparer<string>.Default);
    foreach (var parameter in parameters)
    {
        if (names.ContainsKey(parameter.Name))
        {
            // throw that readonly argument is a assignment
            context.ReportDiagnostic(Diagnostic.Create(rule, names[parameter.Name].GetLocation()));
        }
    }
