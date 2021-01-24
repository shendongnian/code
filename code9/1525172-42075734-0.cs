    var disposeMethodSymbol = ...
    var type = disposeMethodSymbol.ContainingType;
    var isInterfaceImplementaton = type.FindImplementationForInterfaceMember(
                type.Interfaces.Single().
                GetMembers().OfType<IMethodSymbol>().Single()) == disposeMethodSymbol ;
