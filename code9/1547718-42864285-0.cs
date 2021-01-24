    int x = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
        x++;
        textBox1.Text = x.ToString();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        DateTime start = DateTime.Now;
        while ((DateTime.Now - start).TotalSeconds < 4)
        {
            System.Threading.Thread.Sleep(10);
        }
    }
