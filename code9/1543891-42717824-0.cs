    var SqlCom = new SqlCommand("AddWorkProgress");
    SqlCom.CommandType = CommandType.StoredProcedure;
    //... prepare the command. No need to use a connection
    using(var connection=DataBaseConnection.OpenConnection())
    using(var transaction= connection.BeginTransaction()) 
    {
        SqlCom.Connection=connection;
        SqlCom.Transaction=transaction;
        SqlCom.ExecuteNonQuery();
        transaction.Commit();
    }
