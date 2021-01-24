    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        string[] arr = textBox1.Text.Split(':');
        string username = arr[0];
        string password = arr[1];
        // Now you can use the 2 variables in other textboxes
        textUsername.Text = username;
        textPassword.Text = password;
    }
