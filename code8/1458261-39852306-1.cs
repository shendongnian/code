    private void LoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Add this lines, your login form is hidden
            if (this.Visible == false)
            {
                return;
            }            
            DialogResult logoutResult = MessageBox.Show("Do you want to logout?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (logoutResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false; //<- you dont need this
            }
        }
