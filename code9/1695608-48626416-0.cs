    public class MainWindowViewModel  : INotifyPropertyChanged
    {
        public MainWindowViewModel ()
        {
            NavigateCommand = new RelayCommand<string>(GoToStep);
        }
        public ICommand NavigateCommand { get; private set; }
        private IStep _currentStep;
        public IStep CurrentStep
        {
            get { return _currentStep; }
            set { _currentStep = value; NotifyPropertyChanged(); }
        }
        private void GoToStep(string s)
        {
            switch(s)
            {
                case "firstStep":
                    CurrentStep = new FirstStep();
                    break;
                case "secondStep":
                    CurrentStep = new SecondStep();
                    break;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
