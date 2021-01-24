        private ViewModelBaseClass _model = null;
        public ViewModelBaseClass Model {
            get { return _model; }
            set {
                if (value != _model) {
                    _model = value;
                    OnPropertyChanged()
                }
            }
        }
    
        protected void OnPropertyChanged([CallerMemberName] String prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    I'm making up a name for your viewmodel base class. If you don't have a viewmodel base class, the type of `Model` could simply be `Object`. 
