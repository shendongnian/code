    #region Public Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Public Events
        #region Protected Methods
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion Protected Methods
