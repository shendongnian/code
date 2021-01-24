    public string IDNumber
        {
            get
            {
                return iDNumber;
            }
    
            set
            {
                iDNumber = value;
                ShowNextWindow(currentWindow);
                OnPropertyChanged("IDNumber");
            }
        }
