    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
        protected bool SetProperty<T>(ref T storage, T value,
        [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
    public class FertigungDaten : ObservableObject
    { 
        ...
        private int f_Reinigen;
        public int F_Reinigen
        {
            get { return f_Reinigen; }
            set { SetProperty(ref f_Reinigen, value); }
        }
        ...
    }
