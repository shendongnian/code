        private StoredActionsModel _selectedStoredAction;
        public StoredActionsModel SelectedStoredAction
        {
            get { return _selectedStoredAction; }
            set
            {
                if (value != _selectedStoredAction)
                {
                    _selectedStoredAction = value; OnPropertyChanged("SelectedStoredAction");
                }
            }
        }
