        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var className = node.Identifier.Text;
            var namespaceName = (node.Parent as NamespaceDeclarationSyntax)?.Name.ToString();
            var isAbstract = node.Modifiers.Any(x => x.IsKind(SyntaxKind.AbstractKeyword));
        }
