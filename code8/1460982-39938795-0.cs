        public static void  ExecuteScript(string fname, List<string> databases)
        {
            string script = File.ReadAllText(fname);
            ServerConnection conn = new ServerConnection("server-name/instance", "user", "password");
            Server SMOServer = new Server(conn);
          
            // foreach (Database db in SMOServer.Databases) //for all databases in server
            foreach (var dbname in databases)
            {               
                var db = SMOServer.Databases[dbname];
                var ds = db.ExecuteWithResults(script); //if you want query result as a Dataset
              //db.ExecuteNonQuery(script); // if you run non return query result, e.g update/insert/delete
            }
            conn.Disconnect();
        }
