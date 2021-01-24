    public class Controller : INotifyPropertyChanged
    {
        private bool _busy;
        public bool Busy 
        {
            get
            {
                return  _busy;
            } 
            private set
            {
                SetField(ref _busy, value, "Busy"); }
            } 
        }
        public async void GetValue()
        {
            Busy = true;
            await Task.Delay(5000);
            Busy = false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
               handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
