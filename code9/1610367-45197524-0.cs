        private PropertyDeclarationSyntax MakeProperty()
        {
            string name = "n";
            // Create an auto-property
            var property =
                SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("int"), name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddAccessorListAccessors(
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                );
            return property;
        }
        private async Task<Document> AddProperty(Document document, ClassDeclarationSyntax classeDecl, CancellationToken cancellationToken)
        {
            var root = await document.GetSyntaxRootAsync(cancellationToken);
            var newClass = classeDecl.AddMembers(MakeProperty());
            return document.WithSyntaxRoot(root.ReplaceNode(classeDecl, newClass));
        }
