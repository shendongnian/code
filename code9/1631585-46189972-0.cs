     public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                MakeTable();
            }
    
            public async void MakeTable()
            {
                var task = await Task<DataTable>.Factory.StartNew(() =>
                {
                    var tbl = new DataTable();
                    for (int i = 1; i < 5; i++)
                    {
                        tbl.Columns.Add("Coloumn" + i, typeof(int));
                    }
    
                    for (int j = 0; j <= 30; j++)
                    {
                        var nuRow = tbl.NewRow();
                        for (int k = 0; k < 4; k++)
                        {
    
                            nuRow[k] = j;
                        }
                        Thread.Sleep(50);
                        tbl.Rows.Add(nuRow);
                    }
    
                    return tbl;
                });
    
                ExportGrid.ItemsSource = task.DefaultView;
            }
        }
