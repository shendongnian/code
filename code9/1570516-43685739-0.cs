    void TestAttempt()
    {
    
        string source = @"
      Imports System
      Namespace Exceptions
        Public NotInheritable Class ExampleException
          Inherits Validation
    
          Public Sub New()
            X(""Ignore me 1"")
            Console.WriteLine(""Report me"")
            Console.WriteLine(X(""Ignore me 2""))
    
            MyBase.New(X(""Ignore me 3, "" & _
                       ""Because I'm already translated.""))
          End Sub
        End Class
      End Namespace";
    
        var tree = VisualBasicSyntaxTree.ParseText(source);
    
        var syntaxRoot = tree.GetRoot();
        int i = 0, notWrapped = 0;
    
        foreach (var s in syntaxRoot.DescendantNodes().OfType<LiteralExpressionSyntax>())
        {
            // things to skip:
            if (s == null) { continue; }
            if (s.Kind() != SyntaxKind.StringLiteralExpression) { continue; }
            
            if (!IsWrappedInCallToX(s))
            {
                Console.WriteLine($"  Reported: {s.ToString()}");
                notWrapped++;
            }
            i++;
        }
    
        Console.WriteLine();
        Console.WriteLine($"Total: {i}, Not Wrapped In X: {notWrapped}");
    }
    
    bool IsWrappedInCallToX(SyntaxNode node)
    {
        var invocation = node as InvocationExpressionSyntax;
        if (invocation != null)
        {
            var exp = invocation.Expression as IdentifierNameSyntax;
            if (exp != null && exp.ToString() == "X")
            {
                return true;
            }
        }
        if (node.Parent != null)
        {
            return IsWrappedInCallToX(node.Parent);
        }
        return false;
    }
