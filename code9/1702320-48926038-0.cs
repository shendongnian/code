        public ICommand NavigationCandidates
        {
            get
            {
                return _navigationCandidates ?? (_navigationCandidates = new RelayCommand(OnnavigationClicked));
            }
        }
        private void OnnavigationClicked()
        {
           // throw new NotImplementedException();
        }
