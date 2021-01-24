    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var loginForm = new YourLoginDialog();
        var result = YourLoginDialog.ShowDialog();
        if (result == DialogResult.Yes)
        {
            Application.Run(new Scrapper());
        }
        else
        {
            MessageBox.Show("Login failed");
        }
    }
