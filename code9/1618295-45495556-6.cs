    internal sealed class IdentifierVisitor : CSharpSyntaxVisitor<SyntaxToken>
    {
        public static IdentifierVisitor Instance { get; } = new IdentifierVisitor();
        public override SyntaxToken VisitMethodDeclaration(MethodDeclarationSyntax node)
        => node.Identifier;
        public override SyntaxToken VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        => node.Identifier;
        public override SyntaxToken VisitDestructorDeclaration(DestructorDeclarationSyntax node)
        => node.Identifier;
    }
