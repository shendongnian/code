    static void Main(string[] args)
    {
        SyntaxTree tree = CSharpSyntaxTree.ParseText(
            @"using System;
            namespace HelloWorld
            {
                public class MyType{public void MyMethod(){}}
            }"
        );
        var root = (CompilationUnitSyntax)tree.GetRoot();
        var compilation = CSharpCompilation.Create("HelloWorld")
                          .AddReferences(
                             MetadataReference.CreateFromFile(
                               typeof(object).Assembly.Location))
                          .AddSyntaxTrees(tree);
        var model = compilation.GetSemanticModel(tree);
        var myTypeSyntax = root.DescendantNodes().OfType<TypeDeclarationSyntax>().First();
        var myTypeInfo = model.GetDeclaredSymbol(myTypeSyntax);
        Console.WriteLine(myTypeInfo);
    }
