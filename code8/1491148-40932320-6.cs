    string email = TryLogin(textBox1.Text, textBox2.Text);
    if(!string.IsNullOrEmpty(email))
    {
        MessageBox.Show("Welcome To Private Area", decusr);
        Main_Form frm = new Main_Form();
        frm.Show();
        this.Hide();
    }
    else
    {
        MessageBox.Show("Password Or Username Is Wrong!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }    
