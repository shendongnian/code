     public ObservableCollection<ComboBoxPopulation> Selezione
        {
            get
            {
                return selezione;
            }
            set
            {
                if (selezione != value)
                {
                    selezione = value;
                    OnPropertyChanged("Selezione");
                }
            }
        }
