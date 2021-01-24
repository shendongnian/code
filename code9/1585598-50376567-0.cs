    // backup caret position in text
    int backPosition = 
        new TextRange(RichTextBox.CaretPosition.DocumentStart, RichTextBox.CaretPosition).Text.Length;
    // set new content (caret position is lost there)
    RichTextBox.Document.Blocks.Clear();
    SetNewDocumentContent(RichTextBox.Document);
    // find position and run to which place caret
    int pos = 0; Run caretRun = null;
    foreach (var block in RichTextBox.Document.Blocks)
    {
        if (!(block is Paragraph para))
            continue;
        foreach (var inline in para.Inlines){
        {
            if (!(inline is Run run))
                continue;
            // find run to which place caret
            if (caretRun == null && backPosition > 0)
            {
                pos += run.Text.Length;
                if (pos >= backPosition){
                     caretRun = run;
                     break;
                }
            }
        }
        if (caretRun!=null)
            break;
    }
    // restore caret position
    if (caretRun != null)
        RichTextBox.CaretPosition = 
            caretRun.ContentEnd.GetPositionAtOffset(backPosition - pos, LogicalDirection.Forward);
