    private void RichEditControl_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        var tr = new TextRange(richEditControl.Document.ContentStart, richEditControl.Document.ContentEnd);
        e.Handled = tr.Text.Length - richEditControl.Selection.Text.Length>= 4000;
    }
