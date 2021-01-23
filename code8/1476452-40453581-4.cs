    private void PasswordTextBox_KeyPress(object sender, EventArgs e)
            {
                if(e.KeyChar == 13) 
                {
                    MessageBox.Show("You pressed the enter key");
                }
            }
