    private async void PopulateList()
    {
        jobList = (await firebase
            .Child("jobs")
            .OnceAsync<Job>())
            .Select(item =>
                 new Job 
                 { 
                      ID = item.Object.ID, 
                      StartDate = item.Object.StartDate, 
                      EndDate = item.Object.EndDate, 
                      Description = item.Object.Description 
                  });
        SubscribeDbChanges();
    }
