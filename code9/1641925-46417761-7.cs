    class MainViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<JobTimer> JobTimers { get; } = new ObservableCollection<JobTimer>();
        public ICommand AddTimerCommand { get; }
        public MainViewModel()
        {
            AddTimerCommand = new DelegateCommand(_AddTimer);
            _AddTimer();
        }
        private void _AddTimer()
        {
            foreach (JobTimer timer in JobTimers)
            {
                timer.Stop();
            }
            JobTimer t = new JobTimer();
            JobTimers.Add(t);
            t.Start();
        }
    }
