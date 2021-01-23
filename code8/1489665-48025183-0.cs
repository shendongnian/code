     static void Main(string[] args)
        {               
            using (var db = new AdventureWorks2016CTP3Entities())
            {
                db.Database.Connection.StateChange += Connection_StateChange;
                db.Database.Log = (log) => System.Diagnostics.Debug.WriteLine(log);
                var purchase = db.SalesOrderHeader.Select(i => i.SalesPersonID);
                foreach (var m in purchase)
                {
                    Console.WriteLine(m);
                }
            }
        }
        private static void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            if(e.CurrentState == System.Data.ConnectionState.Open)
            {
                var cmd = (sender as System.Data.SqlClient.SqlConnection).CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "exec sp_set_session_context 'UserId', N'290'";
                
                cmd.ExecuteNonQuery();
            }
        }
