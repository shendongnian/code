     //create table and insert data 
    
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
    
     //show inseted value from sqlite 
    
      
    
         private void button2_Click(object sender, EventArgs e)
                {
                    try
                    {
                        conn.ConnectionString = "Driver=SQLite3 ODBC Driver;Datasource=TestOdbc;Version = 3;New=True;Compress=True;";
                        conn.Open();
                        SQLiteCommand comm = new SQLiteCommand();
                        comm.Connection = conn;
                        comm.CommandText = "SELECT * FROM test2";
                        SQLiteDataReader created = comm.ExecuteReader();
                        MessageBox.Show("connection opened!!!");
                        while (created.Read()) // Read() returns true if there is still a result line to read
                        {
                        // Print out the content of the text field:
                        string myreader = "";
                        try
                        {
                            myreader = created[1].ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        label3.Text="  "+myreader;
                    }
                    comm.Dispose();
                    conn.Close();
    
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
            }
    
