    public class ExampleItemViewModel : INotifyPropertyChanged
    {
        private int _Number;
        public int Number
        {
            get { return _Number; }
            set
            {
                _Number = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Calculated");
            }
        }
        public int Calculated { get { return 2 * Number; } }
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string prop = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(prop));
        }
    }
