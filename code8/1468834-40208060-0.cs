        if (count == 1)
        {
            this.Hide();
            form2.Show();
            User.GetUserInfo(login);
            // Update the label text here
            MessageBox.Show(User.name + " " + User.surename);
