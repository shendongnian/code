    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {
        int num1 = Convert.ToInt32(textBox1.Text);
        int num2 = Convert.ToInt32(textBox2.Text);
        string result="";
        for (int i = num1; i <= num2; i++)
        {
            for (int j = num1; j <= num2; j++)
            {
                int res = i * j;
                result=string.format("{0}\n{1}",result,res.ToString());
            }
        }
        textBox3.Text=result;
    }
