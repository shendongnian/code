        const string code = @"
        public class AClass{
            private int MyFld = 5;
            protected double MyProp{get;set;}
            public void AMethod(){
                string myVar = null;
                for (int myIterator=0; myIterator<10;myIterator++)
                    foreach (string str in new int[0].Select(i => i.ToString())){ }
            }
            public void AnotherMethod()
            {
                string anotherVar = null;
            }
        }";
    
-
    
    void Main()
    {
        var tree = CSharpSyntaxTree.ParseText(code);
        var root = tree.GetRoot();
        
        var startNode = root
            .DescendantNodes()
            .OfType<SimpleLambdaExpressionSyntax>() // start at the Select() lambda
            .FirstOrDefault(); 
    
        FindSymbolDeclarationsInAncestors(startNode, "myVar").Dump(); // True
        FindSymbolDeclarationsInAncestors(startNode, "anotherVar").Dump(); // False
        
        CompilationLookUpSymbols(tree, startNode, "myVar").Dump(); // True
        CompilationLookUpSymbols(tree, startNode, "anotherVar").Dump(); // False
    }
    
    // You could manually traverse the ancestor nodes, and find the different DeclarationSyntax-es. 
    // I may have missed some, like CatchDeclarationSyntax..
    // Error-prone but more fun.
    public bool FindSymbolDeclarationsInAncestors(CSharpSyntaxNode currentNode, string symbolToFind)
    {
        return currentNode
            .Ancestors().SelectMany(a => a.ChildNodes()) // get direct siblings
            .SelectMany(node => // find different declarations
                (node as VariableDeclarationSyntax)?.Variables.Select(v => v.Identifier.ValueText)
                ?? (node as FieldDeclarationSyntax)?.Declaration?.Variables.Select(v => v.Identifier.ValueText)
                ?? (node as LocalDeclarationStatementSyntax)?.Declaration?.Variables.Select(v => v.Identifier.ValueText)
                ?? new[] {
                    (node as PropertyDeclarationSyntax)?.Identifier.ValueText,
                    (node as MethodDeclarationSyntax)?.Identifier.ValueText,
                    (node as ClassDeclarationSyntax)?.Identifier.ValueText,
                    })
            .Any(member => string.Equals(member, symbolToFind));
    }
    
    // Or use the SemanticModel from the CSharpCompilation.
    // Possibly slower? Also, not as much fun as manually traversing trees.
    public bool CompilationLookUpSymbols(SyntaxTree tree, CSharpSyntaxNode currentNode, string symbolToFind)
    {
        var compilation = CSharpCompilation.Create("dummy", new[] { tree });
        var model = compilation.GetSemanticModel(tree);
        return model.LookupSymbols(currentNode.SpanStart, name: symbolToFind).Any();
    }
    
