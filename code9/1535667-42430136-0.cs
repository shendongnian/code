        public static int id;
    public void loginuser()
                    {
                        MySqlConnection cnn = new MySqlConnection(mysqlAddress);
                        MySqlCommand cmd;
                        cnn.Open();
                        try
                        {
                            cmd = cnn.CreateCommand();
                            cmd.CommandText = "Insert into employee (logout) values (@logout)";
                            cmd.Parameters.AddWithValue("@logout", dateTimePicker1.Value);
                
                            cmd.ExecuteNonQuery();
                            id = cmd.LastInsertedId; // it will return the id of last inserted row
            
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
            
