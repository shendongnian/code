    private void _1_Load(object sender, EventArgs e)
    {
        await FillA();
        await FillB();
        await FillC();
    }
    private async Task FillA()
    {
        for (int i = 1; i < 10; i++)
        {
            listBox1.Items.Add(i.ToString());
            listBox1.Update();
            await Task.Delay(25);
        }
    }
    private async Task FillB()
    {
        await Task.Delay(3000); //1 seconds delay
        textBox1.Text = "Hello World!";
    }
    private async Task FillC()
    {
        for (int i = 11; i < 100; i++)
        {
            listBox1.Items.Add(i.ToString());
            listBox1.Update();
            await Task.Delay(25);
        }
    }
