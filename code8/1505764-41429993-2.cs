    public class JobViewModel
    {
        public JobViewModel()
        {
            RemoveCommand = new DelegateCommand<object>(argument =>
            {
                Jobs.Remove(argument as Job);
            });
        }
        public ObservableCollection<Job> Jobs { get; } = new ObservableCollection<Job>()
        {
            new Job(),
            new Job(),
            new Job()
        };
        public DelegateCommand<object> RemoveCommand { get; }
    }
