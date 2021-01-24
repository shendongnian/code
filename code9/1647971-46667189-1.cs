    private void grid1_ToolTipOpening(object sender, ToolTipEventArgs e)
    {
        var s = sender as FrameworkElement;
        var be = BindingOperations.GetBindingExpressionBase(s, FrameworkElement.ToolTipProperty);
        if (be != null)
        {
            be.UpdateTarget();
        }
    }
