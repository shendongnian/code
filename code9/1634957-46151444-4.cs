    private void button1_Click(object sender, EventArgs e)
    {
        DatabaseHelper.SetConnection(ip.Text,port.Text, uname.Text, pword.Text);
        Form2 f2 = new Form2();
        f2.Show();
    }
