     private void textBox1_TextChanged(object sender, EventArgs e)
        {
          {
            if ((textBox1.Text.Length) == 1)
            {
                textBox1.Text = textBox1.Text[0].ToString().ToUpper();
                textBox1.Select(2, 1);
               
            }
          }
        }
