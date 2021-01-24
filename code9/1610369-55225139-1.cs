    string log4NetLoggerDeclaration =
                        "private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);";
    
    var log4NetDeclarationStatement = SyntaxHelpers.GenerateClassNode<FieldDeclarationSyntax>(log4NetLoggerDeclaration);
            
    string declarationString = log4NetLoggerDeclaration.ToString();
