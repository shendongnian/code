       public static void Login(string user, string pass) {
            var con = GetConnection();
        
            try {
        
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT username, password WHERE username = @username";
                MySqlDataReader reader = cmd.ExecuteReader();
        
                if (reader.HasRows) {
                    while (reader.Read()) {
                        string pw = reader.GetString(1);
        
                        if (pass == pw) {
                            MessageBox.Show("Welcome");
                            con.Close();
                            reader.Close();
                        } else {
                            MessageBox.Show("Password Incorrect");
                            con.Close();
                            reader.Close();
                        }
                    }
                } else {
                    MessageBox.Show("There is no such user in database");
                    con.Close();
                    reader.Close();
                }
            } catch (Exception e) {
                con.Close();
                MessageBox.Show(Convert.ToString(e));
            } finally {
                con.Close();
            }
        
        }
