    private async void button1_Click(object sender, EventArgs e)
    {
        // run process in background
        await Task.Run(() => Process());
        // return to UI context
        Display(); 
    }
    private void Display()
    {
        // Textbox output
    }
