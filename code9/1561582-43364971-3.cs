        public ViewModel()
        {
            OnButtonFocusCommand = new DelegateCommand(() =>
            {
                this.TextBoxText = "Hello, World";
            });
        }
        public ICommand OnButtonFocusCommand { get; private set; }
