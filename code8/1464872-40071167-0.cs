        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Contains(" "))
            {
                txtPassword.Text = txtPassword.Text.Replace(" ", "");
                txtPassword.SelectionStart = txtPassword.Text.Length;
            }
        }
