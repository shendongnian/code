    public MainWindow()
    {
        this.DataContext = this;
        InitializeComponent();
        DepremlerListesi = new ObservableCollection<ClassToBind>();
        DepremlerListesi.Add(new ClassToBind("test1", "test2"));
        DepremlerListesi.Add(new ClassToBind("test3", "test4"));
        DepremlerListesi.Add(new ClassToBind("test5", "test6"));
        OnPropertyChanged("DepremlerListesi");
    }
