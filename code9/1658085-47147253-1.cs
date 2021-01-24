    public FrameworkElement GetControl()
    {
        if (_Callback != null)
        {
            _Control.SetHeight(_Callback.GetHeight());
        }
        return _Control;
    }
