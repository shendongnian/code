    using MySql.Data.MySqlClient;
    using System;
    
    namespace vmcmod
    {
        public class DBConnection
        {
            public DBConnection()
            {
            }
            public string Password { get; set; }
            private MySqlConnection connection = null;
            public MySqlConnection Connection
            {
                get
                {
                    IsConnect();
                    return connection;
                }
            }
            public bool IsConnect()
            {
                bool result = true;
                if (connection == null)
                {
                    string connString = "Server=...; Port=...; Database=...; Uid=...; Pwd=...;";
                    connection = new MySqlConnection(connString);
                    try
                    {
                        connection.Open();
                        Utils.consoleLog("Connected to repository.", 4);
                        result = true;
                    }
                    catch (Exception e)
                    {
                        Utils.consoleLog("Error occured while connecting to repository.", 3);
                        Utils.consoleLog("MySQL Exception: "+e,5);
                        result = false;
                    }
                }
    
                return result;
            }
    
            public void Close()
            {
                connection.Close();
                connection = null;
            }
        }
    }
