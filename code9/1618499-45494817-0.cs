        static async Task<Type> GetOperationResultTypeAsync(Type left, Type right, string operatorSymbol)
        {
            // Reference all assemblies that are loaded in the current AppDomain (plugins?)
            var options = ScriptOptions.Default.AddReferences(AppDomain.CurrentDomain.GetAssemblies());
            var script = CSharpScript.Create($"var instance = default({left.FullName}) {operatorSymbol} default({right.FullName});", options: options);
            var compilation = script.GetCompilation();
            var syntaxTree = compilation.SyntaxTrees.Single();
            var semanticModel = compilation.GetSemanticModel(syntaxTree);
            var variableDeclaration = (await syntaxTree.GetRootAsync())
                .DescendantNodes()
                .OfType<VariableDeclarationSyntax>()
                .Single();
            var symbolInfo = semanticModel.GetSymbolInfo(variableDeclaration.Type);
            var typeSymbol = (ITypeSymbol)symbolInfo.Symbol; // will be null on error (eg operation not possible/defined/allowed)
            if (typeSymbol == null)
                return null;
            var symbolDisplayFormat = new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);
            string fullyQualifiedName = typeSymbol.ToDisplayString(symbolDisplayFormat);
            Type type = Type.GetType(fullyQualifiedName, throwOnError: true);
            return type;
        }
