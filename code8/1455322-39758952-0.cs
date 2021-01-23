    public class ViewModel: ViewModelBase
    {
        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                _isLoggedIn = value;
                RaisePropertyChanged(() => IsLoggedIn);
            }
        }
        public IEnumerable<string> Items
        { get { return new[] {"One", "Two", "Theee", "Four", "Five"}; } }
    }
