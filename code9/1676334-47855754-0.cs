    private void bunifuFlatButton3_Click(object sender, EventArgs e)
    {
        try 
        {
            conn.Close();
    
            string DeleteQuery = "delete from Stocks_Item where Stock_code = @Stockno";
    
            SqlCommand cmdDelete = new SqlCommand(DeleteQuery, conn);
            -- add the parameter!
            cmdDelete.Parameters.Add("@stockno", SqlDbType.Int).Value = (provide the value for `@stockno` here!);
            // open connection, execute command, close connection
            conn.Open();
            cmdDelete.ExecuteNonQuery();
            conn.Close();
    
            MessageBox.Show("You've deleted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            .....
        }
    }
