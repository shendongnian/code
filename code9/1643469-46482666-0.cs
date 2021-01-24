    public NewDataGrid()
        {
            InitializeComponent();
    
            ItemsSource = new ObservableCollection<object>();
            var dpd = DependencyPropertyDescriptor.FromProperty(ItemsDataSourceProperty, typeof(NewDataGrid));
    
                 
            dpd?.AddValueChanged(this, (s, a) =>
            {
                ItemsSource.Clear();
                ItemsSource.Add(ItemsDataSource.Cast<object>().ToList());
            });
        }
