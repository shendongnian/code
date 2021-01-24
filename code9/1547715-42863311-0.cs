    async Task Timer_Delay(uint delay)
    {
        timer.Stop();
        await System.Threading.Tasks.Task.Delay(delay);
        timer.Start();
    }
