     private void LoginButton_Click(object sender, EventArgs e)
            {
                this.LoginButton.Enabled = false;
                LoginForm.ShowDialog();            
            }
    
        private void Ribbon_Load(object sender, EventArgs e)
                {
                    LoginForm = new LoginForm();
                    LoginForm.FormClosed += LoginForm_Closed;               
                }
    
    
        void LoginForm_Closed(object sender, FormClosedEventArgs e)
                {
                    this.LoginButton.Enabled = true;
                }
