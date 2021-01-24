    private Task drawGraphTask = null;
    
    private void button1_Click(object sender, EventArgs e)
    {
        DrawGraph();
    }
    
    private async void DrawGraph()
    {
        // Only perform task when this is the first time 
        // or the previous task is already completed
        if (drawGraphTask == null || drawGraphTask.IsCompleted)
        {
            drawGraphTask = startTimeConsumingProcess();
            await drawGraphTask;
        }
        else
        {
            MessageBox.Show("Task already active");
        }
    }
    
    private Task startTimeConsumingProcess()
    {
        // Your Code here
        return Task.Delay(5000);
    }
