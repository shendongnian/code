    PDO in dotNET
    [enter link description here][1]
      [1]: https://www.nuget.org/packages/SDO_dotNET/
    
        The SDO_dotNET Class Library is a high level wrapper around the ODBC, OLEDB, SQLServer and SQLite.
    
    Example:
    using SqlDB;
    
    /******************************************************************
    Sql Server
    *******************************************************************/
    
    string server      = @"INSTANCE\SQLEXPRESS";
    string database = "DEMODB";
    string username = "sa";
    string password = "";
    
    string connectionString = @"Data Source=" + server + ";Initial Catalog=" + database + "; Trusted_Connection=True;User ID=" + username + ";Password=" + password + "";
    SDO db_conn = new SDO(connectionString);
    
    Console.WriteLine("isConnected: " + db_conn.isConnected());
    if (db_conn == null || !db_conn.isConnected())
    {
        Console.WriteLine("Connessione non valida.");
        return;
    }
    
    string sql = "SELECT ID, Message FROM Logs ORDER BY IDLic;";
    DataTable dtLogs = db_conn.SelectTable(sql);
    
    if (dtLogs == null || dtLogs.Rows.Count == 0)
        return;
    
    // Loop with the foreach keyword.
    foreach (DataRow dr in dtLogs.Rows)
    {
        Console.WriteLine("Message: " + dr["Message"].ToString().Trim());
    }
    
    
    
    /******************************************************************
    SQLite
    *******************************************************************/
    
    string database = @"C:\Users\Utente\mydb.sqlite";
    
    string connectionString = @"Data Source=" + database + "; Version=3; New=True; Compress=True;"; // local
    SDO db_conn = new SDO(connectionString);
    
    Console.WriteLine("isConnected: " + db_conn.isConnected());
    if (db_conn == null || !db_conn.isConnected())
    {
        Console.WriteLine("Connessione non valida.");
        return;
    }
    
    string sql = "SELECT firstname, surname FROM users ORDER BY firstname;";
    DataTable dtLogs = db_conn.SelectTable(sql);
    
    if (dtLogs == null || dtLogs.Rows.Count == 0)
        return;
    
    // Loop with the foreach keyword.
    foreach (DataRow dr in dtLogs.Rows)
    {
        Console.WriteLine("Name: " + dr["firstname"].ToString().Trim() + " " + dr["surname"].ToString().Trim());
    }
