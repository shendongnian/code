    public static bool executeSqlScript(string scriptPath, string serverName, string databaseName)
        {
            try
            {
                SqlConnection myConn = new SqlConnection("Server=.;Integrated security=SSPI;database=master");
                //Server server = new Server(new ServerConnection(myConn));
                string CreateCommand = "CREATE DATABASE " + databaseName + "";
                string appendText;
                //delete first line from script(Oldscript)
                //create db first
                var myCommand = new SqlCommand(CreateCommand, myConn);
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
                
                List<string[]> list = File.ReadLines(scriptPath)
                    .Select(line => line.ToLower().Split(new string[] { "go" }, StringSplitOptions.None))
                    .ToList();
                Parallel.ForEach(list, (sql) =>
                {
                    using (var mysqlConn = new SqlConnection("Server=.;Integrated security=SSPI;database=master"))
                    {
                        var mysql = "USE [" + databaseName + "]" + Environment.NewLine + string.Join("", sql);
                        var mysqlCommand = new SqlCommand(mysql, mysqlConn);
                        myConn.Open();
                        mysqlCommand.ExecuteNonQuery();
                    }
                });
                
                //server.ConnectionContext.ExecuteNonQuery(readtext);
                return true;
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }
