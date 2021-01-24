     MySqlConnection conn = new MySqlConnection();
            private  int TestB(int returnValue, System.IO.StringWriter writer)
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;database=test;user id=root;password=root;port=3307;characterset=utf8;connectiontimeout=72000;");
                
                    conn.Open();
    
                    // Execute the second command in the second database.
                    returnValue = 0;
                    MySqlCommand command2 = new MySqlCommand("Insert tbb (`time`)value ('10:00:00')", conn);
                    returnValue = command2.ExecuteNonQuery();
                    writer.WriteLine("Rows to be affected by command2: {0}", returnValue);
                    conn.Close();
                   return returnValue;
            }
    
            private  int TestA(int returnValue, System.IO.StringWriter writer)
            {
                conn = new MySqlConnection("server=localhost;database=test1;user id=root;password=root;port=3307;characterset=utf8;connectiontimeout=72000;");
                
                    conn.Open();
    
                    // Create the SqlCommand object and execute the first command.
                    MySqlCommand command1 = new MySqlCommand("Insert tb1 (`Name`, `Value`)value ('ai', '2017-04-26')", conn);
                    returnValue = command1.ExecuteNonQuery();
                    writer.WriteLine("Rows to be affected by command1: {0}", returnValue);
    
                    conn.Close();
    
                return returnValue;
            }
