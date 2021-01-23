    private void loginButton_Click(object sender, EventArgs e)
    {
       var mainMenuForm = new MainMenu();
       mainMenuForm.UserName = userNameTextBox.Text;
       this.Hide();           
       mainMenuForm.Show();
    }
    
    class MainMenu : Form
    {
        // This is an "Auto-Implemented Property".
        // Auto-Implemented Properties are used as a shortcut of what you have done.
        // Google them for more information.
        public string UserName { get; set; }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            userNameLabel.Text = UserName;
        }
    }
