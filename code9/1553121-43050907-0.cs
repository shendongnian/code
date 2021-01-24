    <ComboBox ItemsSource="{Binding Countries}"
              DisplayMemberPath="Name"
              SelectedItem="{Binding SelectedCountry}" />
     
    <ComboBox ItemsSource="{Binding Cities}"
              DisplayMemberPath="Name"
              SelectedItem="{Binding SelectedCity}"
              Margin="0 5 0 0"/>
----------
    public CustomObservableCollection<City> Cities {
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
    ...
    }
