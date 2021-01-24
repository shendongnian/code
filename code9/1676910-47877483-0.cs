     private void CmdNeuerDatenSatz_Click(object sender, RoutedEventArgs e)
        {
            int c = 8;
            int b = 110;
    
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
    
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source = C:\\Users\\Linner OHG\\Desktop\\TestDB.mdb";
    
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO DB_Test (Col_1) VALUES (?)";
    
            // add parameter value
            // note: parameters need to be in the same order as they are in the statement
            var param = new OleDbParameter("Col_1", OleDbType.VarChar));
            param.Value = "my value";
    
            cmd.Parameters.Add(param);
    
            try
            {
                con.Open();
    
                c = cmd.ExecuteNonQuery();
                MessageBox.Show("Row has been inserted!");
    
                con.Close();
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
