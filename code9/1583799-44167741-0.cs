    static async Task<ISymbol> GetEquivalentSymbol(SyntaxNodeAnalysisContext context, FieldDeclarationSyntax field, CancellationToken cancellationToken)
    {
        var solution = context.GetSolution();
        var classDeclaration = field.Ancestors().OfType<ClassDeclarationSyntax>().FirstOrDefault();
        var namespaceDeclaration = field.Ancestors().OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
        var className = classDeclaration?.Identifier.ValueText;
        var initialVariable = field.Declaration.Variables.FirstOrDefault();
        foreach (var project in solution.Projects)
        {
            foreach (var document in project.Documents)
            {
                var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
                var root = await document.GetSyntaxRootAsync(cancellationToken);
                if (null != namespaceDeclaration)
                {
                    var namespaceNode = root.DescendantNodes().OfType<NamespaceDeclarationSyntax>()
                        .FirstOrDefault(node => node.Name.ToString() == namespaceDeclaration.Name.ToString());
                    if (null == namespaceNode)
                    {
                        continue;
                    }
                }
                var classNode = root.DescendantNodes()
                    .OfType<ClassDeclarationSyntax>()
                    .FirstOrDefault(node => node.Identifier.ValueText == className);
                var desiredField = classNode?.DescendantNodes().OfType<FieldDeclarationSyntax>()
                    .FirstOrDefault(x => x.Declaration.Variables.First().Identifier.ValueText == initialVariable.Identifier.ValueText);
                if (desiredField == null)
                {
                    continue;
                }
                var symbol = semanticModel.GetDeclaredSymbol(desiredField.Declaration.Variables.FirstOrDefault());
                return symbol;
            }
        }
        return null;
    }
