    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp; //NuGet package
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    namespace StackOverflow_RosalynExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tree = CSharpSyntaxTree.ParseText(@"
    using System;
    namespace SomeNamespace
    {
        class SomeClass
        {
            public void SomeMethod()
            {
                DateTime example = DateTime.Now;
            }
        }
    }");
                var rewriter = new DateTimeUtcEnsurer();
                var result = rewriter.Visit(tree.GetRoot());
                Console.WriteLine(result.ToFullString());
                Console.ReadKey(); //DateTime.Now -> DateTime.UtcNow
            }
        }
        public class DateTimeUtcEnsurer : CSharpSyntaxRewriter
        {
            public override SyntaxNode VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
            {
                var dateTimeNow = SyntaxFactory.ParseExpression("DateTime.Now") as MemberAccessExpressionSyntax;
                if (SyntaxFactory.AreEquivalent(node, dateTimeNow))
                {
                    var dateTimeUtcNow = SyntaxFactory.ParseExpression("DateTime.UtcNow") as MemberAccessExpressionSyntax;
                    dateTimeUtcNow = dateTimeUtcNow.WithTrailingTrivia(SyntaxFactory.ParseTrailingTrivia(" /*Silly junior dev ;)*/"));
                    return dateTimeUtcNow;
                }
                return base.VisitMemberAccessExpression(node);
            }
        }
    }
