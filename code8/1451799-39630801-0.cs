    if (MessageBow.Show("Are you sure you want to Delete this File?", "Open File", MessageBoxButtons.YesNo) == DialogResult.Yes)
    {
        // define connection string (load from config) and query statement
        string connStr = ".......";
        string qryDelete = "DELETE [DocumentName] FROM DocStorage WHERE DocumentName = @DocShred";
    
        // set up the connection and command 
        using (SqlConnection con = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand(qryDelete, con))
        {
            cmd.Parameters.Add(new SqlParameter("@DocShred", listBox1.SelectedItem.ToString());
            // open connection, execute query, close connection
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
    
        MessageBox.Show("Delete Successful", "File Deleted", MessageBoxButtons.Ok);
    }
