    using System.Threading.Tasks;
    
    private void Form1_Shown(object sender, EventArgs e)
    {
        Load();
    }
    private async void Load()
    {
        // Start the loading animation here
        await Task.Run(() =>
        {
            // Do work here!
        });
        // When the task is complete, stop the loading animation
    }
