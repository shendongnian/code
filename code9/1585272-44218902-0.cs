       SQLiteConnection conn = new SQLiteConnection("data source = zivali.sqlite");
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = "SELECT * FROM login;";
            SQLiteDataReader reader = com.ExecuteReader();
            bool loginValid = false;
            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();
                if (username == textBoxUserName.Text && password == textBoxPassword.Text)
                {
                    loginValid = true;
                    break;
                   
                }
                loginValid = false;
            }
            if (loginValid)
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
            conn.Close();
        }
     
