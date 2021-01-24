    public MainWindow()
    {
        InitializeComponent();
        DependencyPropertyDescriptor
            .FromProperty(ListView.ViewProperty, typeof(ListView))
            .AddValueChanged(listView, ViewChanged);
        listView.View = new GridView();
    }
    private void ViewChanged(object sender, EventArgs e)
    {
        Debug.WriteLine("ViewChanged");
    }
