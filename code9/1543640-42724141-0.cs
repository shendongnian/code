    public static void ExecuteSqlCommand(string connectionString, string sql)
    {
        using (var db = new SqlConnection(connectionString))
        {
    		db.InfoMessage += new SqlInfoMessageEventHandler(db_InfoMessage);
            var count = db.Execute(sql, null, null, 240); 
            Console.WriteLine(count); //can get count of rows affected but not rest of output from Messages Tab in SSMS.
        }
    }
    
    void db_InfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        // handle here and look at e.Message
    }
