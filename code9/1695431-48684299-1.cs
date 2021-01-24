    private async void button1_Click(object sender, EventArgs e)
    {
        this.Enabled = false;
        //Show a loading image
        await Task.WhenAll(new Task[] {
            Task.Run(()=>Task1()),
            Task.Run(()=>Task2()),
        });
        //Hide the loading image
        this.Enabled = true;
    }
