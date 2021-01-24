    public static (string, ImageMoniker)[] GetSyntaxHierarchyAtCaret(IWpfTextView textView)
    {
        var caretPosition =
            textView.Caret.Position.BufferPosition;
    
        var document =
            caretPosition.Snapshot.GetOpenDocumentInCurrentContextWithChanges();
    
        var syntaxRoot =
            document.GetSyntaxRootAsync().Result;
    
        var caretParent =
            syntaxRoot.FindToken(caretPosition).Parent;
    
        var returnValue = new List<(string, ImageMoniker)>();
        while (caretParent != null)
        {
            var kind = caretParent.Kind();
    
            switch (kind)
            {
                case SyntaxKind.ClassDeclaration:
                    {
                        var dec = caretParent as ClassDeclarationSyntax;
                        returnValue.Add((dec.Identifier.ToString(),KnownMonikers.Class));
                        break;
                    }
                case SyntaxKind.MethodDeclaration:
                    {
                        var dec = caretParent as MethodDeclarationSyntax;
                        returnValue.Add((dec.Identifier.ToString(),KnownMonikers.Method));
                        break;
                    }
                case SyntaxKind.PropertyDeclaration:
                    {
                        var dec = caretParent as PropertyDeclarationSyntax;
                        returnValue.Add((dec.Identifier.ToString(), KnownMonikers.Property));
                        break;
                    }
            }
    
            caretParent = caretParent.Parent;
        }
    
        return returnValue.ToArray();
    }
