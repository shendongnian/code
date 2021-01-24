    public void logoutuser()
                {
                    MySqlConnection cnn = new MySqlConnection(mysqlAddress);
                    MySqlCommand cmd;
                    cnn.Open();
                    try
                    {
                        cmd = cnn.CreateCommand();
                        cmd.CommandText = "update employee set logout = @logout";
                        cmd.CommandText += "WHERE IDNUMBER=@ID";
                        cmd.Parameters.AddWithValue("@logout", dateTimePicker1.Value);
                      cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                       
        
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
            
                            MessageBox.Show("Data has been saved");
                        }
                    }
                }
    
        
