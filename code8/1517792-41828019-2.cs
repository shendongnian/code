    private Something _st;
    public Something st
    {
        get
        {
            return _st;
        }
        set
        {
            _st = value;
            OnNotifyPropertyChanged("st");
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        st = new Something();
    }
