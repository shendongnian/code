    namespace WpfStackOverflow.ViewModels
    {
        class BasicMVVMViewModel:ViewModelBase
        {
            private ObservableCollectionEx<LocationKPI> _locations;
            public BasicMVVMViewModel()
            {
                CreateTestData();
            }
            private DateTime _selectedDate;
            public DateTime SelectedDate
            {
                get { return _selectedDate; }
                set
                {
                    _selectedDate = value;
                    SetPropertyChanged();
                    SetSelectedLocationKPI( _selectedDate.Month);
                }
            }
            private LocationKPI _selectedLocationKPI;
            public LocationKPI SelectedLocationKPI
            {
                get { return _selectedLocationKPI; }
                set
                {
                    _selectedLocationKPI = value;
                    SetPropertyChanged();
                }
            }
            private void  SetSelectedLocationKPI(long sMonth)
            {
                SelectedLocationKPI = _locations.Where(p => p.SMonth.Equals(sMonth)).FirstOrDefault();
            }
            private void CreateTestData()
            {
                _locations = new ObservableCollectionEx<LocationKPI>();
                for(int i=0; i < 12;i++)
                {
                    _locations.Add(new LocationKPI() { SMonth = i, Efficiency = i*17 });
                }
            
            }
        }
    }
