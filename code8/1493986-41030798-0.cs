    public class State: INotifyPropertyChanged
    {
        private string a;
        private string b;
        private string c;
        private string d;
        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string A
        {
            get { return this.a; }
            set
            {
                if (value != this.a)
                {
                    this.a= value;
                    NotifyPropertyChanged();
                }
            }
        }
        ... so on and so forth ...
    }
