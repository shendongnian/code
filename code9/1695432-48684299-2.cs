    private async void button1_Click(object sender, EventArgs e)
    {
        this.Enabled = false;
        //Show a loading image
        await Task.Run(()=>Task1());
        await Task.Run(()=>Task2());
        //Hide the loading image
        this.Enabled = true;
    }
