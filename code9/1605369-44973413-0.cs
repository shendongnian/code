    public class MainView_VM : ViewModelBase
    {
        public MainView_VM()
        {
            ReadFile();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<int>(this, index => Index = index);
        }
        public ObservableCollection<string> FileData { get; set; }
        int _Index;
        public int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
                RaisePropertyChanged();
            }
        }
        void ReadFile()
        {
            //I will read file here.
        }
    }
