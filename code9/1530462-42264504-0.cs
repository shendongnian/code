        public MainWindow()
        {
            InitializeComponent(); 
            DataTable tab = new DataTable();
            for (int i = 0; i < 1000; i++)
                tab.Columns.Add("A" + i.ToString());
            for (int i = 0; i < 1000; i++)
            {
                DataRow r = tab.NewRow();
                for (int j = 0; j < 1000; j++)
                    r[j] = "something " + (i * i * j * j).ToString();
                tab.Rows.Add(r);
            }
            DataGrid dg = new DataGrid() { EnableColumnVirtualization = true, EnableRowVirtualization = true };
            this.Content = dg;
            dg.ItemsSource = tab.AsDataView();
            dg.AutoGeneratingColumn += Dg_AutoGeneratingColumn;
        }
        private void Dg_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.MaxWidth = 100;
        }
