    public LoadersRegistry()
        {
            var dataContext = new DataContext();
            Schedule(()=> new InfoLoader(dataContext)).ToRunNow().AndEvery(1).Hours();
        }
