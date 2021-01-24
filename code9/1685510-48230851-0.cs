    public class ViewModel : INotifyPropertyChanged
    {
        private int someValue;
        private bool isEnabled;
        public ViewModel()
        {
            MyCommand = new RelayActionCommand(Click);
        }
        private void Click(object obj)
        {
            //Do something.
        }
        /// <summary>
        /// Bind this to the IsEnabled property of the button, and 
        /// also the background using a convertor or see ButtonBackground.
        /// </summary>
        public bool IsEnabled => SomeValue < 5;
        /// <summary>
        /// Option 2 - use this property to bind to the background of the button.
        /// </summary>
        public Brush ButtonBackground => IsEnabled ? Brushes.SeaShell : Brushes.AntiqueWhite;
        public int SomeValue
        {
            get { return someValue; }
            set
            {
                if (value == someValue) return;
                someValue = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsEnabled));
                OnPropertyChanged(nameof(ButtonBackground));
            }
        }
        /// <summary>
        /// Bind this to the command of the button.
        /// </summary>
        public RelayActionCommand MyCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged
            ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
