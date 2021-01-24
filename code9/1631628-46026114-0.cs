    class MainPageViewModel : INotifyPropertyChanged
    {
        private string _messageContent;
    
        ...
    
        public string MessageContent
        {
            get => _messageContent;
            set
            {
                _messageContent = value;
                OnPropertyChanged();
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
