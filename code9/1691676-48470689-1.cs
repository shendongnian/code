    protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
    {
        base.OnLostKeyboardFocus(e);
        if (ClickMode == ClickMode.Hover)
        {
            // Ignore when in hover-click mode.
            return;
        }
        if (e.OriginalSource == this)
        {
            if (IsPressed)
            {
                SetIsPressed(false);
            }
            if (IsMouseCaptured)
                ReleaseMouseCapture();
            IsSpaceKeyDown = false;
        }
    }
