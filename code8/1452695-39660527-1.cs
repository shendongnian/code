    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                textBox3.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text));
            }
            if (textBox1.Text.Length > 0 && textBox2.Text.Length == 0)
            {
                textBox3.Text = textBox1.Text;
            }
            if (textBox1.Text.Length == 0 && textBox2.Text.Length > 0)
            {
                textBox3.Text = textBox2.Text;
            }
            if(textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
            {
                textBox3.Text = "0";
            }
        }
