    private void LoginWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            // You should keep only one of two:
            #region Behavior 1: Exit the application on invalid password
            this.DialogResult = lblPasswordBox.Password == "1";
            this.Close();
            #endregion
            #region Behavior 2: Warn the user on invalid password
            if (lblPasswordBox.Password == "1")
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("invalid password");
            }
            #endregion
        }
    }
