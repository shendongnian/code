    txtUser.KeyPress += ClearTextboxes;
    txtPass.KeyPress += ClearTextboxes;
    
    private void ClearTextboxes(object sender, KeyPressEventArgs e)
    {
        if (e.KeyCode == Keys.Back) 
        {
            (TextBox)sender.Text = string.Empty();
        }
    }
