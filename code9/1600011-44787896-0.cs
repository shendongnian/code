    public MainPage()
    {
        this.InitializeComponent();
        PATH_INK_CANVAS.InkPresenter.StrokeInput.StrokeEnded += StrokeInput_StrokeEndedAsync;
    }
    private async void StrokeInput_StrokeEndedAsync(InkStrokeInput sender, PointerEventArgs args)
    {
        await Task.Delay(10);
        inkStrokes = PATH_INK_CANVAS.InkPresenter.StrokeContainer.GetStrokes();
        if (inkStrokes.Count > 0)
        {
            var XBound = inkStrokes.Max(a => a.BoundingRect.Bottom);
            if (XBound > PATH_INK_CANVAS.ActualHeight - 400)
                PATH_INK_CANVAS.Height = XBound + 400;
            var YBound = inkStrokes.Max(a => a.BoundingRect.Right);
            if (YBound > PATH_INK_CANVAS.ActualWidth - 400)
                PATH_INK_CANVAS.Width = YBound + 400;
        }
    }
