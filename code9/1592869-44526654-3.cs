    public bool Selezionato
    {
        get { return selezionato; }
        set
        {
            if (selezionato != value)
            {
                selezionato = value;
                OnPropertyChanged("Selezionato");
            }
        }
    }
