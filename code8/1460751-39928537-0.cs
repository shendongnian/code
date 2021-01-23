    using (SqlCommand cmd = new SqlCommand(
                    "CREATE TABLE dbo.MyTable ("
                    + "ID int IDENTITY(1,1) PRIMARY KEY,"
                    + "MyProduct nvarchar(100) NOT NULL,"
                    + "MyDateTime datetime NOT NULL);"
                    + "", sqlConn))
    {
        sqlConn.Open();
        cmd.Connection.Open();  // don't need this...
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
