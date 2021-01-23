        public MySqlDataReader SelectCategory() {
        
                try
                {
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM categories WHERE online = 1";
        
                    connection.Open();
                    MySqlDataReader categories = cmd.ExecuteReader();
                    return categories;
                }        
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }       
        
            }
