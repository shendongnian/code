    static void ReplaceClassName()
    {
        // This class needs to be renamed. We want to use Roslyn and symbols,
        // because string-based replacement would change things that it's not supposed to.
        var someScript = "public class FooBar { public NotFooBar a; FooBar b; public OtherNamespace.FooBar c; }";
        // Minimal Roslyn boilerplate
        var compilation = CSharpCompilation.Create("CodeGeneration")
            .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
            .AddSyntaxTrees(CSharpSyntaxTree.ParseText(someScript));
        var oldSyntaxTree = compilation.SyntaxTrees[0];
        var root = oldSyntaxTree.GetRoot();
        var classDeclaration = root.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
        var semanticModel = compilation.GetSemanticModel(classDeclaration.SyntaxTree);
        var originalType = semanticModel.GetDeclaredSymbol(classDeclaration);
        var rewritten = new TestRewriter(semanticModel, originalType).Visit(root);
        Console.Write(rewritten.GetText());
    }
    class TestRewriter : CSharpSyntaxRewriter
    {
        private readonly SemanticModel _model;
        private readonly ITypeSymbol _replace;
        public TestRewriter(SemanticModel model, ITypeSymbol replace)
        {
            _model = model;
            _replace = replace;
        }
        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            node = base.VisitIdentifierName(node) as IdentifierNameSyntax;
            if (_model.GetTypeInfo(node).Type.Equals(_replace))
            {
                var oldNode = node;
                node = node.ReplaceToken(
                            node.Identifier,
                            SyntaxFactory.Identifier(node.Identifier.Text.Replace("Bar", "Baz"))
                    ).WithLeadingTrivia(oldNode.GetLeadingTrivia()).WithTrailingTrivia(oldNode.GetTrailingTrivia());
            }
            return node;
        }
        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var oldNode = node;
            node = base.VisitClassDeclaration(node) as ClassDeclarationSyntax;
            if (_model.GetDeclaredSymbol(oldNode).Equals(_replace))
            {
                return node.WithIdentifier(SyntaxFactory.Identifier(node.Identifier.Text.Replace("Bar", "Baz")));
            }
            return node;
        }
    }
