	using(var connection = new OleDbConnection("connection string here"))
	{
		connection.Open();
		using(var command = new OleDbCommand("DELETE FROM TBLNAME WHERE name = @name", connection))
		{
			cmd.Parameters.Add(new OleDbParameter("@name", OleDbType.VarChar, 50)).Value = lvlist.SelectedItems[0].Text;
			command.ExecuteNonQuery();
		}
		using(var command = new OleDbCommand("DELETE from TBLNAME WHERE cb_listName = @listname", connection))
		{
			cmd.Parameters.Add(new OleDbParameter("@listname", OleDbType.VarChar, 50)).Value = lvlist.SelectedItems[0].Text;
			command.ExecuteNonQuery();
		}
	}
	
