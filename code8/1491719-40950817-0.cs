    using (var connection = new OleDbConnection())
    using (var command = new OleDbCommand(){Connection = connection,CommandText = query})
    {
	    connection.Open();
    	command.ExecuteNonQuery();
    }
    MessageBox.Show("Successfully Deleted");
