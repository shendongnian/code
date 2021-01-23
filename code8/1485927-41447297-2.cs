    private void buttonSave_Click_1(object sender, EventArgs e) // save to invoice
    {
        SqlConnection con = new SqlConnection(MyConnectionString);
        string SqlCmdText = "INSERT INTO invoice (p_code, p_name, p_category, p_price) " +
                                      VALUES (@code, @name, @category, @price)";
        SqlCommand sc = new SqlCommand(SqlCmdText, con);
        con.Open();
        foreach (DataRow row in MyTable.Rows)
        {
            sc.Parameters.Clear();
            sc.Parameters.AddWithValue("@code", row["p_code"]);
            sc.Parameters.AddWithValue("@name", row["p_name"]);
            sc.Parameters.AddWithValue("@category", row["p_category"]);
            sc.Parameters.AddWithValue("@price", row["p_price"]);
            sc.ExecuteNonQuery();
        }
        con.Close();
    }
