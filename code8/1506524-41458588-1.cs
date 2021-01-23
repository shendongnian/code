    public class DummyViewModel
    {
        private decimal? _fleetAggregate;
        public decimal? FleetAggregate
        {
            get
            {
                return _fleetAggregate;
            }
            set
            {
                _fleetAggregate = value;
                //OnPropertyChanged();
            }
        }
    
    
    }
