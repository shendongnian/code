           SQLiteConnection conn = new SQLiteConnection("data source = zivali.sqlite");
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(conn);
            com.CommandText = "SELECT * FROM login;";
            SQLiteDataReader reader = com.ExecuteReader();
            // place your username/password decleration here, no need to read them X times in a loop
            string username = reader["username"].ToString();
            string password = reader["password"].ToString();
            // bool for if there is any user whith the given cridentials
            bool loginValid = false;
            while (reader.Read())
            {
                // if cridentials mathch set loginValid to true and break out of the loop 
                if (username == textBoxUserName.Text && password == textBoxPassword.Text)
                {
                    loginValid = true;
                    break;
                }
            }
            // check if the login is true
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
     
