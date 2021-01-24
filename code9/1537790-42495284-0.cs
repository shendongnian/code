    public class ViewModel:INofifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void notifyPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
       
        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                notifyPropertyChanged("Login");
            }
        }
    }
