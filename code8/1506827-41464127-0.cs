     public string Tekst
        {
            get
            {
                return model.Tekst;
            }
            set
            {
                model.Tekst = value;
                OnPropertyChanged("Tekst");
                OnPropertyChanged("Wyswietl");
            }
        }
