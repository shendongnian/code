    private static PropertyDeclarationSyntax ConvertToProperty(Type propertyType, string propertyName)
    {
        var typeSyntax = ParseTypeName(propertyType.ToGenericTypeString());
        return PropertyDeclaration(typeSyntax, propertyName)
                .AddModifiers(Token(SyntaxKind.PublicKeyword))
                .AddAccessorListAccessors(
                    AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(Token(SyntaxKind.SemicolonToken)),
                    AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
    }
    var classDeclaration = ClassDeclaration("MyClass");
    classDeclaration = classDeclaration.AddModifiers(Token(SyntaxKind.PublicKeyword));
    classDeclaration = classDeclaration.AddMembers(ConvertToProperty(typeof(int?), "MyProperty"));
    Console.WriteLine(classDeclaration.ToString());
