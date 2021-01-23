    textBox.Text = GetUsername(userID);
    
    string GetUsername(string userID) {
        var resultTable = new DataTable();
        var connection = new SqlConnection("Data Source=METHOUN-PC;Initial Catalog=ITReportDb;Integrated Security=True");
        con.Open();
        var command = new SqlCommand("SELECT Username FROM tblLogin WHERE UserId='" + userID + "';", connection);
        var adapter = new SqlDataAdapter(command);
        adapter.Fill(resultTable);
        con.Close();
        return resultTable.Rows[0]["Username"].ToString();
    }
