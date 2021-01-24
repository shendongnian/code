    public Form1()
    {
        InitializeComponent();
        var setting = ConfigurationManager.AppSettings["setting1"];
        var conn = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        using (var sqlConn = new SqlConnection(conn))
        {
            var sqlQuery = @"SELECT CDU_ESTADOS  from  testetiposdestados";
            MessageBox.Show(sqlQuery);
            using(var cmd = new SqlCommand(sqlQuery, sqlConn))
            {
                using(var da = new SqlDataAdapter(cmd))
                {
                    using(var table = new DataTable())
                    {
                        da.Fill(table);
                        combobox1.DisplayMember = "CDU_ESTADOS";
                        comboBox1.DataSource = new BindingSource(table, null);
                    }
                }
            }
        }
    }
