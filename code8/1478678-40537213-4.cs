    // Eine Kleine Jagermeister!
    public ObservableCollection<Klant> Overzicht
    {
        get { return _Overzicht; }
        set { _Overzicht = value; OnPropertyChanged(); }
    }
    
    public int AantalKlanten { get { return Overzicht?.Count ?? 0; } }
    public int AantalConsumpties { get; set; }
