                   bool UserExists = false;
                command.CommandText = "Select [Username] from LoginTable where Username = '" + Username_txtBx.Text + "'";
                OleDbDataReader reader = command.ExecuteReader();
                
                int g = new int();
                while (reader.Read())
                {
                    UserExists = true;
                }
                connection.Close();
                if (!UserExists)
                {
