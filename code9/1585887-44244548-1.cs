        private List<ISymbol> GetSymbolsOfAttributedMethods(string attributeName)
        {
            var methodDeclarations = semanticModel.SyntaxTree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();
            var symbolList = new List<ISymbol>();
            foreach (var declaration in methodDeclarations)
            {
                foreach (var attributeList in declaration.AttributeLists)
                {
                    if (attributeList.Attributes.Any(a => (a.Name as IdentifierNameSyntax)?.Identifier.Text == attributeName))
                    {
                        symbolList.Add(semanticModel.GetDeclaredSymbol(declaration));
                        break;
                    }
                }
            }
            return symbolList;
        }
