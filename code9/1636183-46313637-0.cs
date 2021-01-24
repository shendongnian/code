    public async Task<ActionResult> DoJob(int id)
    {
        await Task.Delay(TimeSpan.FromSeconds(15));
        return ThreadInfo();
    }
