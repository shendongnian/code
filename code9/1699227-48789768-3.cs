    if (db.Users.Any(o => o.Username == textBoxUser.Text))
    {
        MessageBox.Show("The user " + textBoxUser.Text
                      + " exists! Now I need to check if the password is right");
        User userAccepted = db.Users.First(o => o.Username == textBoxUser.Text);
        MessageBox.Show(userAccepted.Password);
    }
