    private void button_login(object sender, EventArgs e)
    {
       MainMenu username = new MainMenu();
       username.Value1 = textBox1.Text;
       this.Hide();
       username.Show(); // and not ss.Show();
    }
