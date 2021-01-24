    private void BindLeaks()
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LeakConnection"].ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerName, AcctNum, PhoneNum, City, Address, LastLeak from Leak WHERE lastLeak >= CONVERT(datetime, '4-6-2012') ORDER BY LastLeak ASC", conn);
                    DataSet dsLeaks = new DataSet();
                    conn.Open();
                    da.Fill(dsLeaks);
                    conn.Close();
                    GridView1.DataSource = dsLeaks;
                    GridView1.DataBind();
                }
    
            }
