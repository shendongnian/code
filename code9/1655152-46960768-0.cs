    class MyViewModel : PropertyChangedBase
    {
        private bool _isBadLogin;
        public bool IsBadLogin
        {
            get => _isBadLogin;
            set => Set(ref _isBadLogin, value);
        }
    }
