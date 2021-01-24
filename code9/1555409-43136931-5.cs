    try
    {
    con.Open();
    OleDbCommand cmd = new OleDbCommand();
    cmd.Connection = con;
    cmd.CommandText = "alter table [" +tableName + "] add [" + columnName + "] long";
    cmd.ExecuteNonQuery();
    }
    catch(Exception ex)
    {
      //do your processing
    }
    finally
    {
          con?.Close();
    }
