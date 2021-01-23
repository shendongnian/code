    protected BaseViewModel()
    {
        if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
        {
            _app = (App)Application.Current;
        }
    }
