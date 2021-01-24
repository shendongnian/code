    public class UserControlViewModel : INotifyPropertyChanged
    {
        public UserControlViewModel()
        {
            Text = "Started!";
        }
        private string _text;
    
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
    
        public void UserControlClicked()
        {
            Text = "Clicked!";
        }
    
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
