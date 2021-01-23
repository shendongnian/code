        public MainWindow(FileParametersViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            dataGrid.ItemsSource = vm.lParams;
            for (int i = 0; i < vm.ParamNames.Count(); i++)
            {
                DataGridTextColumn col = new DataGridTextColumn();
                col.Header = vm.ParamNames[i];
                string path = String.Format("pArray[{0}]", i);
                col.Binding = new Binding(path);
                dataGrid.Columns.Add(col);
            }
        }
