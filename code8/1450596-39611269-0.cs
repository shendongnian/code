    Stopwatch sw = new Stopwatch();
    
    private void button1_Click(object sender, EventArgs e)
    {
        // First we need to know if it's the first click or the second.
        // We can do this by checking if the timer is running (i.e. starts on first click, stops on second.
        if(sw.IsRunning) // Is running, second click.
        {
            // Stop the timer and compare the elapsed time.
            sw.Stop();
            if(sw.ElapsedMilliseconds > 1000)
            {
                textBox1.Text = "Speed reached!";
            }
        }
        else // Not running, first click.
        {
            // Start the timer from 0.
            sw.Restart();
        }
    }
