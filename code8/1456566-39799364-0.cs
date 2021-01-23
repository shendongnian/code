    // Create '#define X' trivia
    var defineXDirective = SyntaxFactory.ParseCompilationUnit("#define X");
    var leadingTrivia = new List<SyntaxTrivia>
    {
       SyntaxFactory.Trivia(defineXDirective.GetFirstDirective()),
       SyntaxFactory.SyntaxTrivia(SyntaxKind.EndOfLineTrivia, Environment.NewLine)
    };
    
    // Insert '#define X' trivia on top of the document
    var changedRoot = editor.OriginalRoot.WithLeadingTrivia(
                        editor.OriginalRoot.GetLeadingTrivia().InsertRange(0, leadingTrivia));
    editor.ReplaceNode(editor.OriginalRoot, changedRoot);
