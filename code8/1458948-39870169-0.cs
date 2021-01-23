    string query = "Select * from MyTable Where username = @username";
    using (OleDbCommand cmd = new OleDbCommand(query, con))
    {
       cmd.Parameters.Add("@username", OleDbType.VarChar).Value = comboBox1.Text;
    }
