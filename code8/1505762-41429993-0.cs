    public class Job
    {
    }
    public class JobViewModel
    {
        public ObservableCollection<Job> Jobs { get; } = new ObservableCollection<Job>()
        {
            new Job(),
            new Job(),
            new Job()
        };
    }
