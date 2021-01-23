     public partial class MainWindow : Window
     {
        public MainWindow()
        {
            InitializeComponent();
            DataTable dt = GetTable();
            ComboBox.ItemsSource = dt.AsDataView();
        }
        static DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Rows.Add("Rom1");
            table.Rows.Add("Rom2");
            table.Rows.Add("Rom2");
            return table;
        }
     }
