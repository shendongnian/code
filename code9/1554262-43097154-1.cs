    using (OleDbConnection connection = new OleDbConnection("yourConnectionString"))
    {
        OleDbDataAdapter adap;
        DataTable dt = new DataTable();
        OleDbCommand comd = new OleDbCommand();
        comd.Connection = connection;
        comd.Parameters.AddWithValue("@param", txt_DOB.Text);
        comd.CommandText = "SELECT * FROM Players WHERE DOB= '%@param%'";
        adap = new OleDbDataAdapter(comd);
        adap.Fill(dt);
        if(dt.Rows.Count ==0)
            MessageBox.Show("You must register before you can add activities!");
    }
