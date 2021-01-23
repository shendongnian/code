       public RelayCommand StartProcess
        {
            get
            {
                return new RelayCommand(Execute);
            }
        }
        private void Execute()
        {
            IsStartButtonEnabled = false;
        }
