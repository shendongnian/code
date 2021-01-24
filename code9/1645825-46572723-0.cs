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
            var classDeclaration = root.DescendantNodes().OfType<ClassDeclarationSyntax>().Single();
            var originalType = compilation.GetSemanticModel(classDeclaration.SyntaxTree).GetDeclaredSymbol(classDeclaration);
            var renamedClass = classDeclaration.ReplaceToken(
                classDeclaration.Identifier,
                SyntaxFactory.Identifier(classDeclaration.Identifier.Text.Replace("Bar", "Baz"))
            ).WithAdditionalAnnotations(new SyntaxAnnotation("ReplacedClass"));
            root = root.ReplaceNode(classDeclaration, renamedClass);
            compilation = compilation.ReplaceSyntaxTree(oldSyntaxTree, renamedClass.SyntaxTree);
            renamedClass = compilation.SyntaxTrees[0].GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault(curr => curr.GetAnnotations("ReplacedClass").Any());
            var semanticModel = compilation.GetSemanticModel(compilation.SyntaxTrees[0]);
            var renamedType = semanticModel.GetDeclaredSymbol(renamedClass);
            var rewritten = new TestRewriter(semanticModel, originalType, renamedType).Visit(renamedClass);
            Console.Write(rewritten.GetText());
        }
