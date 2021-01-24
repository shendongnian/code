    private void GetCanvasRender(out CanvasRenderTarget renderTarget, float opacity)
    {
        CanvasDevice device = CanvasDevice.GetSharedDevice();
        renderTarget = new CanvasRenderTarget(device, (int)ink.ActualWidth, (int)ink.ActualHeight, 96);
        using (var ds = renderTarget.CreateDrawingSession())
        {
            ds.Clear(Colors.Transparent);
            using (ds.CreateLayer(opacity))
            {
                ds.DrawInk(ink.InkPresenter.StrokeContainer.GetStrokes());
            }
        }
    }
