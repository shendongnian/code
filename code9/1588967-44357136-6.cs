     private void UserCombobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CurrentSelectedUser != null && !string.IsNullOrEmpty(CurrentSelectedUser?.Email?.Trim()))
            {
                //perform what you wana do with the email.
            }
        }
