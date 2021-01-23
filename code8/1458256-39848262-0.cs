    private void LoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            DialogResult logoutResult = MessageBox.Show("Do you want to logout?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (logoutResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
