    public Form1()
    {
        InitializeComponent();
        string setting = ConfigurationManager.AppSettings["setting1"];
        string conn = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        using (SqlConnection sqlConn = new SqlConnection(conn))
        {
            string sqlQuery = @"SELECT CDU_ESTADOS  from  testetiposdestados";
            MessageBox.Show(sqlQuery);
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            combobox1.DisplayMember = "CDU_ESTADOS";
            comboBox1.DataSource = new BindingSource(table, null);
        }
    }
