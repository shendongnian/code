      public string DisplayName
        {
            get { return Model.DisplayName; }
            set 
            {
                Model.DisplayName = value;
                OnPropertyChanged();
            }
        } 
