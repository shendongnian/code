    internal class StateStyleViewModel : INotifyPropertyChanged
    {
        private bool hasWorkState;
        private string workState;
        public event PropertyChangedEventHandler PropertyChanged;
        private string WorkState
        {
            get { return workState; }
            set
            {
                if (value == workState) return;
                workState = value;
                OnPropertyChanged();
                //Notify that the value of the dependent property has changed.
                OnPropertyChanged(nameof(DisplayWorkState));
            }
        }
        public bool HasWorkState
        {
            get { return hasWorkState; }
            set
            {
                if (value == hasWorkState) return;
                hasWorkState = value;
                OnPropertyChanged();
                //Notify that the value of the dependent property has changed.
                OnPropertyChanged(nameof(DisplayWorkState));
            }
        }
        /// <summary>
        /// Property for binding
        /// </summary>
        public string DisplayWorkState => HasWorkState ? WorkState : $"({WorkState})";
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
