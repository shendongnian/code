	using (OleDbConnection Conn = new OleDbConnection("connectionStringHere"))
	using (OleDbCommand Command = new OleDbCommand("UPDATE [TABLE] SET c_qty= ? WHERE id = ?", Conn))
	{
		Command.Parameters.Add(new OleDbParameter("@qty", OleDbType.Int) {Value = int.Parse(txtQty.Text)});
		Command.Parameters.Add(new OleDbParameter("@ID",  OleDbType.Int) {Value = int.Parse(txtID.Text)});
		Conn.Open();
		
		var rowsUpdated = Command.ExecuteNonQuery();
		// output rowsUpdated to the log, should be 1 if id is the PK
    }
