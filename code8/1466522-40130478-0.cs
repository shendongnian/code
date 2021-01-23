    private float value = 0;
    private void button3_Click(object sender, EventArgs e)
    {
        Random b = new Random();
        float value = b.Next(50, 100);
    }
    private void button2_Click(object sender, EventArgs e)
    {
        if (value < MinValue)
        {
            textBox18.Text = ("warning");
            textBox18.ForeColor = Color.White;
            textBox18.BackColor = Color.Red;
        }
    }
