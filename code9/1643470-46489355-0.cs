    public partial class NewDataGrid : DataGrid
    {
        public NewDataGrid()
        {
            InitializeComponent();
            //Removed the DependencyPropertyDescriptor
        }
    
        public IList ItemsDataSource
        {
            get { return (IList)GetValue(ItemsDataSourceProperty); }
            set { SetValue(ItemsDataSourceProperty, value); }
        }
    
        public static readonly DependencyProperty ItemsDataSourceProperty =
                DependencyProperty.Register("ItemsDataSource", typeof(IList), typeof(NewDataGrid), new PropertyMetadata(null, ItemsDataSourceChanged));
    
        private static void ItemsDataSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var grid = sender as NewDataGrid;
            if (grid == null) return;
    
            grid.ItemsSource = ((IList)args.NewValue).Cast<object>().ToList();
        }
    } 
