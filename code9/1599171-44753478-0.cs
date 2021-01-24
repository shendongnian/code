    DTE2 dte = this.ServiceProvider.GetService(typeof(DTE)) as DTE2;
    EnvDTE.Document doc = dte.ActiveDocument;
    EnvDTE.TextDocument tdoc = (EnvDTE.TextDocument)doc.Object("TextDocument");
    EnvDTE.EditPoint objEditPt = tdoc.StartPoint.CreateEditPoint();
    string text = objEditPt.GetText(tdoc.EndPoint);
    SyntaxTree tree = CSharpSyntaxTree.ParseText(text);
    
    IEnumerable<SyntaxNode> nodes = ((CompilationUnitSyntax)tree.GetRoot()).DescendantNodes();
    
    List<LocalDeclarationStatementSyntax> variableDeclarationList = nodes
                    .OfType<LocalDeclarationStatementSyntax>().ToList();
