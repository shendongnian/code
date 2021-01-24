    if(comboBox1.SelectedIndex == 0)
        {
            int fact;
            fact = int.Parse(textBox1.Text);
            factorialPow(fact, 0, 0, 0);
            textBox2.Text = answer.ToString();
        }
        if(comboBox1.SelectedIndex == 1)
        {
            x = double.Parse(textBox1.Text);
            y = double.Parse(textBox3.Text);
            factorialPow(0, x, y, 1);
            textBox2.Text = Convert.ToString(result);
        }
