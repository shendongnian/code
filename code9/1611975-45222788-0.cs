    private void listNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql = "SELECT * FROM members WHERE Name = @Name";
        using (connection = new SqlConnection(connectionString))
        using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
        {
            //guessing at column type/length here
            adapter.SelectCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 20).Value = listNames.SelectedItem;
            DataSet info = new DataSet();
            adapter.Fill(info);
            labelDetailsMonth.Text = info.Tables[0].Rows[0]["Month"].ToString();
            labelDetailsDay.Text = info.Tables[0].Rows[0]["Day"].ToString();
        }
    }
