    var model = compilation.GetSemanticModel(tree);
    var methodDeclarations = classitem.DescendantNodes().OfType<MethodDeclarationSyntax>();
    foreach (var memmeth in methodDeclarations)
    {
        var varInvocations = memmeth.DescendantNodes().OfType<InvocationExpressionSyntax>();
        foreach (InvocationExpressionSyntax invoc in varInvocations)
        {
            Console.WriteLine("---- Invocations---");
            Console.WriteLine(invoc.Expression);  // output: b1.ADD
            Console.WriteLine(invoc.Expression.Parent.GetText()); // output: b1.ADD(2)
            var invokedSymbol = model.GetSymbolInfo(invoc).Symbol;
            Console.WriteLine(invokedSymbol.ToString()); //AppTest.B.ADD(int)
            Console.WriteLine(invokedSymbol.ContainingSymbol); //AppTest.B
            Console.WriteLine(invokedSymbol.ContainingSymbol.Name); //B  
        }
    }
