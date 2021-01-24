    try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;";
                con.Open();
                string str = "USE master;" +
               "EXEC sp_attach_db @dbname = N'TellDB' , " +
                 " @filename1 = N'" + System.Environment.CurrentDirectory + "\\Data\\TellDB.mdf'," +
                 "@filename2 = N'" + System.Environment.CurrentDirectory + "\\Data\\TellDB_log.ldf'";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Attach the database successfully");
            }
            catch (Exception x)
            {
                if (x.Message.IndexOf("already exists") >= 0)
                    MessageBox.Show("The database is available");
                else
                    MessageBox.Show(x.Message);
            }
