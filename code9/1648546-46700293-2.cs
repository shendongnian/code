    // declare connection string class-level instead of MySqlConnection
    string connectionString = "server=localhost;database=buku;uid=fkrfdllh;pwd=*********"
    
    try 
    {
        if (empty_input)
        {
            MessageBox.Show("message text");
        }
        else
        {
            // wrap both MySqlConnection & MySqlCommand on using statements
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("[command_text]", conn))
                {
                    cmd.Parameters.AddWithValue("[param_name]", value);
    
                    // other parameters here
    
                    cmd.ExecuteNonQuery();
    
                    MessageBox.Show("[success_message]");
    
                    // other methods
                }
    
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
