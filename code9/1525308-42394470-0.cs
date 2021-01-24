    class SelectionColorizerWithBackground : ColorizingTransformer
    {
        ICSharpCode.AvalonEdit.Editing.TextArea _textArea;
        public SelectionColorizerWithBackground(
            ICSharpCode.AvalonEdit.Editing.TextArea textArea)
        {
            if (textArea == null)
                throw new ArgumentNullException("textArea");
            this._textArea = textArea;
        }
        protected override void Colorize(ITextRunConstructionContext context)
        {
            int lineStartOffset = context.VisualLine.FirstDocumentLine.Offset;
            int lineEndOffset = context.VisualLine.LastDocumentLine.Offset +
                context.VisualLine.LastDocumentLine.TotalLength;
            foreach (var segment in _textArea.Selection.Segments)
            {
                int segmentStart = segment.StartOffset;
                if (segmentStart >= lineEndOffset)
                    continue;
                int segmentEnd = segment.EndOffset;
                if (segmentEnd <= lineStartOffset)
                    continue;
                int startColumn;
                if (segmentStart < lineStartOffset)
                    startColumn = 0;
                else
                    startColumn = context.VisualLine.ValidateVisualColumn(
                        segment.StartOffset, segment.StartVisualColumn,
                        _textArea.Selection.EnableVirtualSpace);
                int endColumn;
                if (segmentEnd > lineEndOffset)
                    endColumn =
                        _textArea.Selection.EnableVirtualSpace
                            ? int.MaxValue
                            : context.VisualLine
                                     .VisualLengthWithEndOfLineMarker;
                else
                    endColumn = context.VisualLine.ValidateVisualColumn(
                        segment.EndOffset, segment.EndVisualColumn,
                        _textArea.Selection.EnableVirtualSpace);
                ChangeVisualElements(
                    startColumn, endColumn,
                    element => {
                        element.TextRunProperties.SetBackgroundBrush(
                            System.Windows.Media.Brushes.Transparent);
                        if (_textArea.SelectionForeground != null)
                        {
                            element.TextRunProperties.SetForegroundBrush(
                                _textArea.SelectionForeground);
                        }
                    });
            }
        }
    }
