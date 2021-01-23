    private void FillGridView()
        {
            CS = ConfigurationManager.ConnectionStrings["HRMSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM EMP_Master", con))
                {
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                     DataTable dt = new DataTable();
                    ad.Fill(dt);
                    gridView.DataSource = dt;
                }
            }
        } 
  
