        private ICommand _selectPointCommand;
        ICommand SelectPointCommand
        {
            get
            {
                Console.WriteLine("This is executed once");
                return _selectPointCommand;
            }
            set
            {
                if (_selectPointCommand != value)
                {
                    _selectPointCommand = value;
                    OnPropertyChanged("SelectPointCommand");
                }
            }
        }
