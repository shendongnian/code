        OleDbConnection conn = 
           new OleDbConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
        try
        {
            conn.Open();
            var cmd = new OleDbCommand("SELECT 
                                        IFNULL(Testing,'[Y/N]') AS Testing
                                        FROM tbl_Testing
                                        WHERE ID = @param1", conn);
            cmd.Parameters.AddWithValue("param1", Request.QueryString["sId"].ToString());
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    string result = reader.GetString(0);
                    ddlTesting.SelectedValue = result;
                    ddlTesting.AppendDataBoundItems = true;
                }
            }
        }
        finally
        {
            conn.Close();
        }
