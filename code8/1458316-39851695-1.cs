    public class ViewModel : INotifyPropertyChanged
    {
        private string _Status = "Not Started";
        public string Status
        {
            get { return _Status; }
            set
            {
                if (_Status != value)
                {
                    _Status = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
                }
            }
        }
        private CancellationTokenSource tokenSource = null;
        private CancellationToken CancellationToken => tokenSource?.Token ?? CancellationToken.None;
        private Task task;
        public event PropertyChangedEventHandler PropertyChanged;
        public async void LongAction()
        {
            Status = "Running";
            for (int i = 0; i < 1000; i++)
            {
                if (CancellationToken.IsCancellationRequested)
                    break;
                await Task.Delay(5);
            }
            if(CancellationToken.IsCancellationRequested)
                Status = "Cancelled";
            else
                Status = "Completed";
        }
        public void AultifuntionsAccess()//access points for your view
        {
            switch (Status)
            {
                case "Running":
                    Cancel();
                    break;
                case "Not Started":
                case "Completed":
                case "Cancelled":
                    Start();
                    break;
                default:
                    break;
            }
        }
        public void Start()
        {
            Status = "Starting";
            tokenSource = new CancellationTokenSource();
            task = Task.Run((Action)LongAction);
        }
        public void Cancel()
        {
            Status = "Cancelling";
            tokenSource.Cancel();
        }
    }
