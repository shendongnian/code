    public class MainViewModel : INotifyPropertyChanged
    {
        public RelayCommand DoSomethingCommand { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
