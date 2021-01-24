    using System.Threading.Tasks;
    
    private async void Form1_Shown(object sender, EventArgs e)
    {
        // Start the loading animation here
        await Task.Run(() =>
        {
            // Do work here!
        });
        // When the task is complete, stop the loading animation
    }
