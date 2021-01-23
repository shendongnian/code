    private Task submitTask;
    
    private void Submit()
    {
        this.submitTask = Task.Factory.StartNew(() => 
        {
            // Some Code
        } 
    }
    private async void button_Click(object sender, EventArgs e)
    {
    
        // Awaiting will prevent blocking your UI    
        await this.submitTask;
    
        // Some Code    
    }
