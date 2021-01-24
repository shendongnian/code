    private void frmChart_Load(object sender, EventArgs e)
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(cs))
                {
                    SqlCommand cmdSum = new SqlCommand("Select distinct(UserName),sum(Value) from mytable  group by UserName", Con);
                    Con.Open();
                    SqlDataReader reader = cmdSum.ExecuteReader();
                    while (reader.Read())
                    {
                        chart1.DataBindTable(reader, reader["Value"]);
                    }
                    
                }
                foreach (Series series in chart1.Series)
                {
                    series.CustomProperties = "DrawingStyle=LightToDark";
                }
    
            }
