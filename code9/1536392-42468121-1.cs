    private ViewWrapper _viewTemplate;
    public ViewWrapper ViewTemplate
    {
        get { return _viewTemplate; }
        set { _viewTemplate = value; SelectionChanged(); }
    }
