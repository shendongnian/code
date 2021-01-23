    private async void PopulateList()
    {
        IReadOnlyCollection<Firebase.Xamarin.Database.FirebaseObject<Job>> items = await firebase
            .Child("jobs")
            .OnceAsync<Job>();
        jobList = new ConcurrentDictionary<string, Job>();
    
        foreach (var job in items)
        {
            while (!jobList.TryAdd(job.Object.ID, job.Object)) ;
        }
        list = FindViewById<ListView>(Resource.Id.listJobs);
        list.ChoiceMode = ChoiceMode.Single;
        HomeScreenAdapter ListAdapter = new HomeScreenAdapter(this, jobList);
        list.Adapter = ListAdapter;
        SubscribeToDbChanges();
    
    
    }
