    private void SubscribeDbChanges()
    {
        firebase
            .Child("jobs")
            .AsObservable<Job>()
            .Where(job => !jobList.Contains(job.Object))
            .Subscribe(jobItem =>
                {
                });
    }
