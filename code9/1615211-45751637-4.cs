    private readonly IWpfTextView _textView;
    private readonly DispatcherTimer _throttleCursorMove;
    ...
    // constructor
    {
        _textView.Caret.PositionChanged += HandleCaretPositionChanged;
        _throttleCursorMove = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
        _throttleCursorMove.Tick += (sender, args) => CaretPositionChanged();
        _throttleCursorMove.Interval = new TimeSpan(0, 0, 0, 0, 200);
    }
    private void HandleCaretPositionChanged(object sender, CaretPositionChangedEventArgs e)
    {
        if (!_throttleCursorMove.IsEnabled)
            _throttleCursorMove.Start();
    }
    private void CaretPositionChanged()
    {
        _throttleCursorMove.Stop();
        ...
        var hierarchy = CodeHierarchyHelper.GetSyntaxHierarchyAtCaret(_textView);
        ...
    }
    ...
