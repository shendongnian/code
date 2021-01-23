     public MainWindow()
        {
            InitializeComponent();
            list = new ObservableCollection<DataItem>();
            DataItem i1 = new DataItem(3,6,8);
            DataItem i2 = new DataItem(1, 2, 6);
            DataItem i3 = new DataItem(9, 7, 22);
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);
            datagrid.ItemsSource = list;
        }
        public ObservableCollection<DataItem> list;
        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int index = e.Row.GetIndex();
            list[index].total = list[index].val1 + list[index].val2 + list[index].val3;
        }
