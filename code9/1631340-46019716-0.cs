    using System.Data.Odbc;
    
    string connectString = "Driver={PostgreSQL UNICODE};Port=5432;Server=localhost;Database=myDBname;Uid=myusername;Pwd=mypassword;";
     
    OdbcConnection connection = new OdbcConnection(connectString);
    
    connection.Open();
    
    string sql = "select version()";
    OdbcCommand cmd = new OdbcCommand(sql, connection);
    
    OdbcDataReader dr = cmd.ExecuteReader();
    dr.Read();
    string dbVersion = dr.GetString(0);
