      private LeafSide _selectedSide;        
        public LeafSide SelectedSide
        {
            get { return _selectedSide; }
            set { _selectedSide = value; NotifyPropertyChanged("SelectedSide"); }
        }
