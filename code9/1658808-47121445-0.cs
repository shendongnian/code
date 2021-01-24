    public ObservableCollection<City> Cities {
      get;
      private set;
    }
    
    private Country _selectedCountry;
    public Country SelectedCountry {
      get {
        return _selectedCountry;
      }
      set {
        _selectedCountry = value;
        this.Cities.Repopulate(_selectedCountry.Cities);
      }
    }
