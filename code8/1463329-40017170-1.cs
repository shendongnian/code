       DataSet ds = new DataSet("dts");
            using (SqlConnection conn = new SqlConnection
              ("Data Source=;Initial  Catalog=;User ID=;Password="))
            {
                try
                {
        SqlCommand sqlComm = new  SqlCommand("usp_FCS_GetUnitInfo_Takaya",conn);
                    sqlComm.Parameters.AddWithValue("@p1", MachineName);
                    sqlComm.Parameters.AddWithValue("@p2", "serial");
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    da.Fill(ds);
                }
                catch (Exception e)
                {
                    label6.Visible = true;
                    label6.Text = string.Format
                  ("Failed to Access  Database!\r\n\r\nError: {0}", ex.Message);
                    return;
                }
