    private void button1_Click(object sender, EventArgs e)
            {
                // We use these three SQLite objects:
                SQLiteConnection conn;
                SQLiteCommand sqlite_cmd;
                SQLiteDataReader sqlite_datareader;
    
                // create a new database connection:
                conn = new SQLiteConnection("Driver = SQLite3 ODBC Driver; Datasource = TestOdbc;Version = 3;New=True;Compress=True;");
    
                // open the connection:
                conn.Open();
    
                // create a new SQL command:
                sqlite_cmd = conn.CreateCommand();
    
                // Let the SQLiteCommand object know our SQL-Query:
                sqlite_cmd.CommandText = "CREATE TABLE test2 (id integer primary key, text varchar(100));";
    
                // Now lets execute the SQL ;D
                sqlite_cmd.ExecuteNonQuery();
    
                // Lets insert something into our new table:
                sqlite_cmd.CommandText = "INSERT INTO test2 (id, text) VALUES (1, 'Test Text 1');";
    
                // And execute this again ;D
                sqlite_cmd.ExecuteNonQuery();
                label4.Text = "test2";
                label5.Text = "TestOdbc";
                // We are ready, now lets cleanup and close our connection:
                conn.Close();
            }
