    Task t = Task.WhenAll(
        from partition in partitioner.Select((jobs, i) => new { jobs, i })
        select Task.Run(async () =>
        {
            using (partition.jobs)
            {
                while (partition.jobs.MoveNext())
                {
                    Console.WriteLine(partition.i);
                    await CreateJobs(partition.jobs.Current);
                }
            }
        }));
