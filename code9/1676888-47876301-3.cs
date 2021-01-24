    private string Generate()
    {
        var sb = new StringBuilder();
        //TODO: Create the text with a StringBuilder as shown above.
        return sb.ToString();
    }
    private async Task<string> GenerateAsync()
    {
        return await Task.Run(() => Generate());
    }
    private async void button1_Click(object sender, EventArgs e)
    {
        label6.Text = "Generating Code.. Please wait....";
        string text = await GenerateAsync();
        textBox2.Text = text;
        label6.Text = "Done.";
    }
