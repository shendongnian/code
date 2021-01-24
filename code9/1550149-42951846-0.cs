    public class FormMain : Form
    {
        private string _previousUsername;
        
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            using(var loginForm = new FormLogin())
            {
                loginForm.Username = _previousUsername;
                // this will block here, until the loginForm's DialogResult is set
                var result = loginForm.ShowDialog();
                if(result != DialogResult.OK)
                    return;
                // verify loginForm.Username, loginForm.Password
            }
        }
    }
    public class FormLogin : Form
    {
        // wrapper property
        public string Username 
        { 
            get { return textboxUsername.Text; }
            set { textboxUsername.Text = value; }
        }
        public string Password 
        { 
            get { return textboxPassword.Text; }
            set { textboxPassword.Text = value; }
        }
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
