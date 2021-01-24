    string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog ='C:\USERS\uppy8\Desktop\Computer Science Project\Mining Game\Assets\MineRace.mdf'; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
            SqlConnection con = new SqlConnection();   
                        if (con.State==ConnectionState.Open)
                        {
                            con.Close();
                            con.ConnectionString = connectionString;
                            con.Open();
                            cmd.Connection = con;
                        }
                        else
                        {
                            con.ConnectionString = connectionString;
                            con.Open();
                            cmd.Connection = con;
                        }
