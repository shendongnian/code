    public partial class ShowDataGrid : Window //2nd Window is called "ShowDataGrid" here
	{
		public DataTable dataTable2; //declare a public datatable variable
		public ShowDataGrid(DataTable dataTable2) 
		{
			InitializeComponent();
			datagridName.ItemsSource = dataTable2.DefaultView;
		}	
	}
