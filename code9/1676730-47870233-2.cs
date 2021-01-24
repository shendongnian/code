     public List<Ideas> Ideas
     {
        get { return Ideas; }
        set
        {
            Ideas= value; // Endless loop
            OnPropertyChanged();
        }
     }
