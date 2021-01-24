    public MainPage()
    {
        this.InitializeComponent();
        PATH_INK_CANVAS.InkPresenter.StrokeInput.StrokeEnded += StrokeInput_StrokeEndedAsync;
    }
    private async void StrokeInput_StrokeEndedAsync(InkStrokeInput sender, PointerEventArgs args)
    {
        await Task.Delay(100);
        var XBound = PATH_INK_CANVAS.InkPresenter.StrokeContainer.BoundingRect.Bottom;
        if (XBound > PATH_INK_CANVAS.ActualHeight - 400)
            PATH_INK_CANVAS.Height = XBound + 400;
        var YBound = PATH_INK_CANVAS.InkPresenter.StrokeContainer.BoundingRect.Right;
        if (YBound > PATH_INK_CANVAS.ActualWidth - 400)
            PATH_INK_CANVAS.Width = YBound + 400;
    }
