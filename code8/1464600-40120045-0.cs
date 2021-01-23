        SQLiteConnection conn;
        
        // (code omitted)
        private void setPwButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(passwordTextBox.Text))
                conn.ChangePassword(passwordTextBox.Text);
            else
                MessageBox.Show("Please specify a password!");
        }
        private void clearPwButton_Click(object sender, EventArgs e)
        {
            conn.ChangePassword(String.Empty);
        }
