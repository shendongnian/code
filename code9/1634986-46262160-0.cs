    public async Task WorkerStartedMathod()
    {
        for(int i = 0; i<=250; i++)
        {
            List<Task> tasks = new List<Task>();
            tasks.add(Taks.Run(auv0Genetic_DoWork));
            tasks.add(Taks.Run(auv0Genetic_DoWork));
            tasks.add(Taks.Run(auv0Genetic_DoWork));
            tasks.add(Taks.Run(auv0Genetic_DoWork));
            tasks.add(Taks.Run(auv0Genetic_DoWork));
            tasks.add(Taks.Run(auv0Genetic_DoWork));
            await Task.WhenAll(tasks);
        }
    }
