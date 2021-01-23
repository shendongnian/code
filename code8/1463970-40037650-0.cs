        private void btn_login_Click(object sender, EventArgs e)
            {
                BELog.Acctname = txb_accName.Text;
                BELog.Password = txb_password.Text;
        
                
        
                if (txb_accName.Text == "" || txb_password.Text == "")
                {
                    MessageBox.Show("Some fields are empty. Please fill up all fields before clicking LOGIN button.", "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlDataReader dr;
                    dr = BALog.Login(BELog);
                    if (dr.HasRows == true)
                    {
                        dr.Read();
                        Inventory Inv = new Inventory();
                        Inv.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You have entered your password or account name incorrectly. Please check your password and account name and try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dr.Close();
                    }
                }
                
