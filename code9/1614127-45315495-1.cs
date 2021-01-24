    public String MessageRichTextBox()
    {
        rtbMessage.Document = new FlowDocument(p);
        TextRange textRange = new TextRange(
            rtbMessage.Document.ContentStart,
            rtbMessage.Document.ContentEnd
        );
        return textRange.Text;
    }
