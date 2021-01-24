    private void button1_Click(object sender, EventArgs e)
    {
        if(!new EmailAddressAttribute().IsValid(textBox1.Text))
        {
            MessageBox.Show("Email is not valid");
        }
        else
        {
            MessageBox.Show("Email is valid");
        }
    }
