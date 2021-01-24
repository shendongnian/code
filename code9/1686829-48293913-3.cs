    public class MainViewModel : ViewModelBase
    {
        private string vsmConnectionStatus = "";
        public string VsmConnectionStatus
        {
            get => vsmConnectionStatus;
            set
            {
                vsmConnectionStatus = value;
                RaisePropertyChanged("VsmConnectionStatus");
            }
        }
        public MainViewModel()
        {}
    }
