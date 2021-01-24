     public class RegionRemoval : CSharpSyntaxRewriter
        {
            public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
            {
             
                if(node.HasLeadingTrivia)
                {
                    var enumerator = node.GetLeadingTrivia().GetEnumerator();
    
                    while(enumerator.MoveNext())
                    {
                        var syntaxTrivia = enumerator.Current;
                        if(syntaxTrivia.Kind().Equals(SyntaxKind.RegionDirectiveTrivia))
                        {
                            node = node.ReplaceTrivia(syntaxTrivia, SyntaxFactory.Whitespace("\n"));
                        }
                    }
    
                }
                return node;
            }
        }
    
        class RoslynTry
        {
            public static void RegionRemover()
            {
                //A syntax tree with an unnecessary semicolon on its own line
                var tree = CSharpSyntaxTree.ParseText(@"
                      #region Classes
            public class MyClass
            {
            }
    
            public class MyClass2
            {
                #region Methods
                #endregion
            }
            #endregion
            ");
    
                var rewriter = new RegionRemoval();
                var result = rewriter.Visit(tree.GetRoot());
                Console.WriteLine(result.ToFullString());
            }
        }
    
