    public object ViewModel
    {
        get { return _vm; }
        set { _vm = value; NotifyPropertyChanged(); }
    }
    ...
    ViewModel = new CodeViewViewModel(); //displays the CodeView
