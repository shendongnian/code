    String connectionString = "Data Source=*******;Initial Catalog=MaleFemale;Integrated Security=True";
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sql = "insert into TableMaleFemale(Name,EiD,Gender) values (@Name, @EiD, @Gender)"
            using(SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.Add("@Name").Value   = NametextBox.Text == null   ? DBNull.Value : NametextBox.Text;
                cmd.Parameters.Add("@EiD").Value    = EiDtextBox.Text == null    ? DBNull.Value : EiDtextBox.Text;
                cmd.Parameters.Add("@Gender").Value = GendertextBox.Text == null ? DBNull.Value : GendertextBox.Text;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
    }
