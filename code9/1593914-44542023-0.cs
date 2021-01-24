     private async void metroButton1_Click(object sender, EventArgs e)
        {
            string res= await login();
            if (res.Equals("true"))
            {
                this.Hide();
                MainMDIParent mdi = new MainMDIParent();
                mdi.Show();
                btnLogin.Enabled = true;
            }
            else
            {
                MessageBox.Show("Invalid User Credentials", "LOgin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Text = "";
                txtUsername.Text = "";
                btnLogin.Enabled = true;
            }
        }
