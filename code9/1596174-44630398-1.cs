    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        if (!sizeInfo.WidthChanged)
        {
            base.OnRenderSizeChanged(sizeInfo);
            return;
        }
        Hide();
        base.OnRenderSizeChanged(sizeInfo);
        //Last action was on left expander
        if(_lastAction == ExpandActions.CollapseLeft || _lastAction == ExpandActions.ExpandLeft)
        {
            Left -= (sizeInfo.NewSize.Width - sizeInfo.PreviousSize.Width);
        }                    
        Show();
    }
