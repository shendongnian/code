    private void SubscribeToDbChanges()
    {
        firebase
        .Child("jobs").AsObservable<Job>()
        .Where(job => !jobList.ContainsKey(job.Object.ID) && job.EventType == Firebase.Xamarin.Database.Streaming.FirebaseEventType.InsertOrUpdate)
        .Subscribe(job =>
        {
            if (job.EventType == Firebase.Xamarin.Database.Streaming.FirebaseEventType.InsertOrUpdate)
            {
                while (!jobList.TryAdd(job.Object.ID, job.Object)) ;
            }
        });
        firebase
        .Child("jobs").AsObservable<Job>()
        .Where(job => jobList.ContainsKey(job.Object.ID) && job.EventType == Firebase.Xamarin.Database.Streaming.FirebaseEventType.Delete)
        .Subscribe(job =>
        {
            Thread remove = new Thread(() =>
            {
                Job removed = null;
                jobList.TryRemove(job.Object.ID, out removed);
            });
            remove.Start();
        });
    
    }
