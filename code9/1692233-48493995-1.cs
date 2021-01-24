    int count = 0;
    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            count++;
        }
        else if (e.Button == MouseButtons.Right)
        {
            count--;
        }
        label1.Text = count.ToString();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        // The name of the setting here is `Count`.
        // You can change it to something else if you want.
        count = Properties.Settings.Default.Count;
        label1.Text = count.ToString();
    }
    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        Properties.Settings.Default.Count = count;
        Properties.Settings.Default.Save();
    }
