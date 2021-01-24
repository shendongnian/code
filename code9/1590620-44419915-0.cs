    private async void button1_Click(object sender, EventArgs e)
    {
        bool onLine = false;
        Stopwatch chrono = new Stopwatch();
        chrono.Start();
        while (chrono.ElapsedMilliseconds < 2000)
        {
            if (!State().Equals(Online))
            {
                await Task.Delay(250);
            }
            else
            {
                onLine = true;
                break;
            }
        }
    
        if (onLine)
        {
            operationCompleted();
        }
        else
        {
            MessageBox.Show("Error");
        }
    }
