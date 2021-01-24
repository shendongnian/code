    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            CountriesCollection = new ObservableCollection<Country>();
            StateCollection = new ObservableCollection<State>();
            LoadData();
        }
        private ObservableCollection<Country> _CountriesCollection;
        public ObservableCollection<Country> CountriesCollection
        {
            get { return _CountriesCollection; }
            set
            {
                _CountriesCollection = value;
                NotifyPropertyChanged("CountriesCollection");
            }
        }
        private ObservableCollection<State> _StatesCollection;
        public ObservableCollection<State> StateCollection
        {
            get { return _StatesCollection; }
            set
            {
                _StatesCollection = value;
                NotifyPropertyChanged("StateCollection");
            }
        }
        private Country _SelectedCountry;
        public Country SelectedCountry
        {
            get { return _SelectedCountry; }
            set
            {
                _SelectedCountry = value;
                if (_SelectedCountry != null && _SelectedCountry.States != null)
                {
                    StateCollection = new ObservableCollection<State>(_SelectedCountry.States);
                }
                NotifyPropertyChanged("SelectedCountry");
            }
        }
        private void LoadData()
        {
            if (CountriesCollection != null)
            {
                CountriesCollection.Add(new Country
                {
                    CountryId = 1,
                    CountryName = "India",
                    States = new List<State>
                                {
                                        new State { StateId = 1, StateName = "Gujarat"},
                                        new State { StateId = 2, StateName = "Punjab"},
                                        new State { StateId = 3, StateName = "Maharastra"}
                                }
                });
                CountriesCollection.Add(new Country
                {
                    CountryId = 2,
                    CountryName = "Chine",
                    States = new List<State>
                                {
                                        new State { StateId = 4, StateName = "Chine_State1"},
                                        new State { StateId = 5, StateName = "Chine_State2"},
                                        new State { StateId = 6, StateName = "Chine_State3"}
                                }
                });
                CountriesCollection.Add(new Country
                {
                    CountryId = 3,
                    CountryName = "japan",
                    States = new List<State>
                                {
                                        new State { StateId = 7, StateName = "Japan_State1"},
                                        new State { StateId = 8, StateName = "Japan_State2"},
                                        new State { StateId = 9, StateName = "Japan_State3"}
                                }
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
