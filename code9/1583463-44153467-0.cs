     string consString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
           static  String AppSetting1=ConfigurationManager.AppSettings["keyFinancialYr"].ToString();
           static  String AppSetting2=ConfigurationManager.AppSettings["keyFinancialQtr"].ToString();
            String QueryStr = "insert into yourTable(Col1,Col2)values('" + AppSetting1 + "','" + AppSetting2 + "')";
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                ExecuteQuery(consString,QueryStr);
            }
           
            public int ExecuteQuery(String connectionString,string query)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        int result = cmd.ExecuteNonQuery();
                        return result;
                    }
                }
            }
