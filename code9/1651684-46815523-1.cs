        if (textBox1.Text == string.Empty)
        {
            errorProvider1.SetError(textBox1, "Enter value");
        }
        if (textBox2.Text == string.Empty)
        {
            errorProvider2.SetError(textBox2, "Enter value");
        }
        if (textBox3.Text == string.Empty)
        {
            errorProvider3.SetError(textBox3, "Enter value");
        }
        if(textBox1.Text == string.Empty || textBox1.Text == string.Empty || textBox3.Text == string.Empty)
        {
            return;
        }
