    // Get your semantic model
    var semanticModel = compilation.GetSemanticModel(tree);
    //Or
    var semanticModel = document.GetSemanticModelAsync();
    // Get the method you want to find references to.
    // You have a lot of ways to do that, but for example:
    var method = doc.GetSyntaxRootAsync().
         Result.DescendantNodes().
         OfType<InvocationExpressionSyntax>().
         First();
    //Or
    var method = root.DescendantNodes().
         OfType<InvocationExpressionSyntax>().
         First();
    //Then get the symbol info of the method
    var methodSymbol = semanticModel.GetSymbolInfo(method).Symbol;
    // And finally
    SymbolFinder.FindReferencesAsync(methodSymbol, solution).Result
