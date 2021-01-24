    public partial class MainWindow : Window
    {
      SqlConnection connection;
      string connectionString;
      public MainWindow()
      {
        InitializeComponent();
        connectionString = ConfigurationManager.ConnectionStrings["projekt1.Properties.Settings.Database1ConnectionString"].ConnectionString;
        DisplayBMI();
      }
      //private void MainWindow_Load(object sender, EventArgs e)
      //{
      //  DisplayBMI();
      //}
      private void DisplayBMI()
      {
        using (connection = new SqlConnection(connectionString))
        using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Table ", connection))
        {
            DataTable tabelabmi = new DataTable();
            adapter.Fill(tabelabmi);
            listbmi.DisplayMemberPath = "bmi";
            listbmi.SelectedValuePath = "Id";
            listbmi.ItemsSource = tabelabmi.DefaultView;
        }
      }
    }
