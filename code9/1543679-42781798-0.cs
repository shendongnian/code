    public class MyCommand
    {
        private readonly IWpfTextView _textView;
        private readonly MyFormatter _formatter;
        private readonly ITextDocument _document;
        private readonly ITextBufferUndoManager _undoManager;
        public MyCommand(IWpfTextView textView, MyFormatter formatter, ITextDocument document, ITextBufferUndoManager undoManager)
        {
            _textView = textView;
            _formatter = formatter;
            _document = document;
            _undoManager = undoManager;
        }
        public void Format()
        {
            var input = _textView.TextSnapshot.GetText();
            var output = _formatter.format(input);
            using (var undo = _undoManager.TextBufferUndoHistory.CreateTransaction("Format"))
            using (var edit = _undoManager.TextBuffer.CreateEdit(EditOptions.DefaultMinimalChange, 0, null))
            {
                edit.Replace(0, _textView.TextSnapshot.Length, output);
                edit.Apply();
                undo.Complete();
            }
        }
    }
