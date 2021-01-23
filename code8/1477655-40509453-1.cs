    public CustomDataGrid()
    {
        InitializeComponent();
        BindingOperations.SetBinding(Column1, DataGridColumn.WidthProperty, new Binding
        {
            Path = new PropertyPath(Column1WidthProperty),
            Source = this,
        });
        BindingOperations.SetBinding(Column2, DataGridColumn.WidthProperty, new Binding
        {
            Path = new PropertyPath(Column2WidthProperty),
            Source = this,
        });
    }
