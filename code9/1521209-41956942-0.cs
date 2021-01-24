    public MainWindow()
    {
        InitializeComponent();
        DataTable dt = new DataTable();
        dt.Columns.Add("Date");
        dt.Columns.Add("User");
        dt.Columns.Add("Type");
        for (int i = 1; i < 10; ++i)
        {
            var row = dt.NewRow();
            row["Date"] = 1;
            row["User"] = 2;
            row["Type"] = 3;
            dt.Rows.Add(row);
        }
        dgv_Transations.ItemsSource = dt.DefaultView;
        dgv_Transations.Loaded += (s, e) =>
        {
            if (dt.Rows.Count > 0)
            {
                DataGridRow r = dgv_Transations.ItemContainerGenerator.ContainerFromIndex(dt.Rows.Count - 1) as DataGridRow;
                r.Background = Brushes.Red;
            }
        };
    }
