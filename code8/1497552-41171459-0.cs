    cb = new MySqlConnectionStringBuilder()
                {
                    AllowBatch = true,
                    Server = this.host,
                    Port = this.port,
                    UserID = this.dbuser,
                    Password = this.dbpassword,
                    Database = this.database,
                    SslMode = MySqlSslMode.None,
                    Keepalive = 60,
                    ConnectionProtocol = MySqlConnectionProtocol.Tcp,
                    CharacterSet = "utf8"
                    
                    
                };
                cb.ConnectionProtocol = MySqlConnectionProtocol.Tcp;
    
                MySqlConnection connection = new MySqlConnection(cb.GetConnectionString(true));
    
     MySqlCommand cmd;
                MySqlDataReader reader;
                try
                {
                    Console.WriteLine("Mysql client conn");
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandText = queryString;
                    cmd.Prepare(); ....
