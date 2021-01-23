    DTE dte = (DTE)GetService(typeof(DTE));
    if (dte.ActiveDocument != null)
    {
        var selection = (TextSelection)dte.ActiveDocument.Selection;
        string text = selection.Text;
        
        // Modify the text, for example:
        text = ">>" + text + "<<";
        
        // Replace the selection with the modified text.
        selection.Text = text;
    }
