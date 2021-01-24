     bool doesMatch = false;
     string username = reader["username"].ToString();
     string password = reader["password"].ToString();
     while (reader.Read())
     {
           if (username == textBoxUserName.Text && password == textBoxPassword.Text)
          {
                doesMatch = true;
          }
     } 
     if (doesMatch)
     {
        this.Hide();
        Form1 f1 = new Form1();
        f1.ShowDialog();
     }
     else
     {
        MessageBox.Show("Wrong username or password");
     }
