    public void ProcessMethod1([TimerTrigger("0 0/30 * * * *")] TimerInfo timer)
    {
        using (var scope = container.BeginLifetimeScope())
        {
            //Logic
        }
    }
