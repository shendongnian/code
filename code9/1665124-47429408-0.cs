     public ObservableCollection<BorgRealestate> Panden
            {
                get
                {           
                    return ocPanden ?? (ocPanden = new ObservableCollection<BorgRealestate>());
                }
                set
                {
                    if (ocPanden == value)
                        return;
    
                    ocPanden = value;
                    OnPropertyChanged("Panden");
                }
            }
