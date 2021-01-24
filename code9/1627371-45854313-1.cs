        public class Jobs
        {
            public string JobsId { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
        }
        public class RootModel : INotifyPropertyChanged
        {
            List<Jobs> jobList;
            public List<Jobs> JobList
            {
                get { return jobList; }
                set
                {
                    if (jobList != value)
                    {
                        jobList = value;
                        OnPropertyChanged();
                    }
                }
            }
            Jobs selectedJob;
            public Jobs SelectedJob
            {
                get { return selectedJob; }
                set
                {
                    if (selectedJob != value)
                    {
                        selectedJob = value;
                       OnPropertyChanged();
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
