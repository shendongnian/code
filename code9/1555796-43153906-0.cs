    private void InsertRecords(StringCollection sc)
    {
        const string sqlStatement = "INSERT INTO Ingredients_List (Ingredients1) VALUES";
        StringBuilder sb = new StringBuilder(sqlStatement);
        string[] splitItems = null;
        foreach (string item in sc)
        {
            if (item.Contains(","))
            {
                splitItems = item.Split(",".ToCharArray());
               sb.AppendFormat("{0}('{1}'); ", sqlStatement, splitItems[0]);
            }
        }
        //  conn.Open();
        using (SqlConnection connn = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sb.ToString(), connn))
            {
                connn.Open();
                //      cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                connn.Close();
            }
            // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);
        }
    }
