    tooltipSource?.Cancel();
    tooltipSource = new CancellationTokenSource();
    Task tooltipTask = new Task((tokenObj) => {
        string paramValue = WaferMap.getParamValueFromMousePointerXY(LocalMousePosition.X, LocalMousePosition.Y, 1, true).ToString();
        ((CancellationToken)tokenObj).ThrowIfCancellationRequested();
        MethodInvoker setTooltip = delegate() {
            MousePointDisplay.SetToolTip(RefBar, paramValue);
        };
        RefBar.Invoke(setTooltip);
    }, tooltipSource.Token);
    tooltipTask.Start();
