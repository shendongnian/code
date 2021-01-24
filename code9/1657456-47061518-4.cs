    private void btnActivate_Click(object sender, EventArgs e)
    {
        bool activated = false;
        if (textBox1.Text.Length > 7)
        {
            string mac = textBox1.Text;
            string str1 = mac.Substring(4, 1);
            string str2 = mac.Substring(5, 1);
            string str3 = mac.Substring(7, 1);
            string str4 = mac.Substring(2, 1);
            string pattern = str1 + str2 + str2 + str3 + str4;
            activated = textBox2.Text == pattern;
        }
        if (activated)
        {
            MessageBox.Show("Program activated!!!");
            Activate();
            ShowForm2();
        }
        else
        {
            MessageBox.Show("Wrong key");
        }
    }
