    Task.Run(() => {
        string paramValue = WaferMap.getParamValueFromMousePointerXY(LocalMousePosition.X, LocalMousePosition.Y, 1, true).ToString();
        MethodInvoker setTooltip = delegate() {
            MousePointDisplay.SetToolTip(RefBar, paramValue);
        };
        RefBar.Invoke(setTooltip);
    });
