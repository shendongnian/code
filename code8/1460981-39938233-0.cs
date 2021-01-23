            FileInfo file = new FileInfo("C:\\LS\\SmartStats.sql");
            string script = file.OpenText().ReadToEnd();
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            Server server = new Server(new ServerConnection(conn));
            var databaseNames = new List<String> {"database1", "database2"};
            foreach (var databaseName in databaseNames)
            {
                server.ConnectionContext.ExecuteNonQuery("USE " + databaseName + Environment.NewLine + "GO" + Environment.NewLine + script);
            }
