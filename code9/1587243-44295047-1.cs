    private void button1_Click(object sender, EventArgs e)
    {
        double nr1;
        double nr2;
        if (!double.TryParse(textBox1.Text, out nr1))
        {
            MessageBox.Show("Please enter a valid number in textBox1");
            textBox1.Select();
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.TextLength;
        }
        else if (!double.TryParse(textBox2.Text, out nr2))
        {
            MessageBox.Show("Please enter a valid number in textBox2");
            textBox2.Select();
            textBox2.SelectionStart = 0;
            textBox2.SelectionLength = textBox2.TextLength;
        }
        else
        {
            double nr3 = nr1 + nr2;
            textBox3.Text = nr3.ToString();
        }
    }
