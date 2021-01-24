    public class HauptfensterViewModel : INotifyPropertyChanged
    {
        public static HauptfensterViewModel Instance { get; } = new HauptfensterViewModel();
        private HauptfensterViewModel()
        {
        }
        private bool _property1;
        private bool _property2;
        private bool _property3;
        private bool _property4;
        public bool Property1
        {
            get { return _property1; }
            set
            {
                _property1 = value;
                OnPropertyChanged();
            }
        }
        public bool Property2
        {
            get { return _property2; }
            set
            {
                _property2 = value;
                OnPropertyChanged();
            }
        }
        public bool Property3
        {
            get { return _property3; }
            set
            {
                _property3 = value;
                OnPropertyChanged();
            }
        }
        public bool Property4
        {
            get { return _property4; }
            set
            {
                _property4 = value; 
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
