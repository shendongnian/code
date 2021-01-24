    public MainPage()
    {
        this.InitializeComponent();
        editor.Document.SetText(Windows.UI.Text.TextSetOptions.None, @"This is a text for testing.");
        editor.AddHandler(PointerMovedEvent, new PointerEventHandler(editor_PointerMoved), true);
    }
    private void editor_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        var position = e.GetCurrentPoint(editor).Position;
    
        var range = editor.Document.GetRangeFromPoint(position, Windows.UI.Text.PointOptions.ClientCoordinates);
    
        System.Diagnostics.Debug.WriteLine(range.StartPosition);
    }
