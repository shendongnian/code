    public UCVorschau()
    {
        InitializeComponent();
        DataContext = this; //Here is an error
        this.Title = "Vorschaubild";
    }
    public string Title { get; set; }
