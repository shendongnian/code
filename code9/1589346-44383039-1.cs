    string typeToMatchString = "Dictionary<string, Func<Exception, HashSet<object>, Task>>"
    foreach (var parameter in node.ParameterList.Parameters)
    {
        var typeSyntax = parameter.Type;
        var typeSymbol = semanticModel.GetTypeInfo(typeSyntax).Type;
        // Maybe comparing the name is enough?
        if (typeSymbol.ToDisplayString() == typeToMatchString) 
            //PROFIT???       
    }
