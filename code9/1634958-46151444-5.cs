    private void button1_Click(object sender, EventArgs e)
    {
        OracleConnection con = DatabaseHelper.GetConnection();
    
        OracleCommand cmd = new OracleCommand();
        cmd.CommandText = "Select name from username";
        cmd.Connection = con;
        con.Open();
        OracleDataReader dr = cmd.ExecuteReader();
        dr.Read();
        label1.Text = dr.GetString(0);
    }
