    var sshPrivateKey = ConfigurationManager.AppSettings["SSHPrivateKeyPath"];
                System.IO.Stream privateKey = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(sshPrivateKey);
                PrivateKeyFile privateKeyStream = new PrivateKeyFile(privateKey, string.Empty);
                var sshHostAddress = ConfigurationManager.AppSettings["SSHHostAddress"];
                var sshPort = ConfigurationManager.AppSettings["SSHPort"];
                var sshUser = ConfigurationManager.AppSettings["SSHUser"];
                var ci = new PrivateKeyConnectionInfo(sshHostAddress, port: Convert.ToInt32(sshPort), username: sshUser, privateKeyStream);
                using (var client = new SshClient(ci)) // establishing ssh connection to server where MySql is hosted
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                        client.AddForwardedPort(portForwarded);
                        using (MySqlConnection SqlConn = new MySqlConnection(Config.ConnectionString()))
                        {
                            SqlConn.Open();
                            command.Connection = SqlConn;
                            command.CommandType = CommandType.StoredProcedure;
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                // do stuff
                            }
                        }
                        client.Disconnect();
                    }
                    else
                    {
                        Console.WriteLine("Client cannot be reached...");
                    }
                }
