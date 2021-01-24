        public ViewModel()
        {
            OnButtonFocusCommand = new DelegateCommand<RoutedEventArgs>(args =>
                {
                    this.TextBoxText = "Hello, World";
                });
        }
