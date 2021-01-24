    Conn.Open();
    Command.CommandType = CommandType.Text;
    Command.CommandText ="UPDATE [TABLE] SET c_qty= ? WHERE id = ?";
    
    Command.Parameters.Add(new OleDbParameter("@qty", OleDbType.Int) {Value = int.Parse(txtQty.Text)});
    Command.Parameters.Add(new OleDbParameter("@ID",  OleDbType.Int) {Value = int.Parse(txtID.Text)});
    var rowsUpdated = Command.ExecuteNonQuery();
    // output rowsUpdated to the log, should be 1 if id is the PK
    Conn.Close();
