    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {
        int num1 = Convert.ToInt32(textBox1.Text);
        int num2 = Convert.ToInt32(textBox2.Text);
        
        for (int i = num1; i <= num2; i++)
        {
            for (int j = num1; j <= num2; j++)
            {
                int res = i * j;
                textBox3.Text += res.ToString() + " ";
            }
        }
    }
