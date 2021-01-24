    private async void _1_Load(object sender, EventArgs e)
    {
        await AddInitialListBoxItems();
        await FillTextBox();
        await AddRemainingListBoxItems();
    }
    private async Task AddInitialListBoxItems()
    {
        for (int i = 1; i < 10; i++)
        {
            listBox1.Items.Add(i.ToString());
            listBox1.Update();
            await Task.Delay(25);
        }
    }
    private async Task FillTextBox()
    {
        await Task.Delay(3000); //1 seconds delay
        textBox1.Text = "Hello World!";
    }
    private async Task AddRemainingListBoxItems()
    {
        for (int i = 11; i < 100; i++)
        {
            listBox1.Items.Add(i.ToString());
            listBox1.Update();
            await Task.Delay(25);
        }
    }
