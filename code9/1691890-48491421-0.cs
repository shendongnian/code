    TextRange textRange = new TextRange() { StartIndex = 3, Length = 10 };            
    TextHighlighter highlighter = new TextHighlighter()
    {
        Background = new SolidColorBrush(Colors.Yellow),
        Ranges = { textRange }
    };
    //add the highlighter
    RichBlock.TextHighlighters.Add(highlighter);
