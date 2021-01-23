    private void button_login(object sender, EventArgs e)
    {
       MainMenu ss= new MainMenu(textBox1.Text);
       this.Hide();            
       ss.Show();
    }
    class MainMenu : Form
    {
        // This is an "Auto-Implemented Property".
        // Auto-Implemented Properties are used as a shortcut of what you have done.
        // Google them for more information.
        public string UserName { get; set; }
    
        private void MainMenu(string userName)
        {
            this.UserName = userName;
        }
    }
