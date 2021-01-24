      public class Car : ModelBase
      {
        public Car()
        {
            AllowedDrivers = new ObservableCollection<Person>();
        }
        private string _model;
        public string Model
        {
            get { return _model; }
            set { this.Update(x => x.Model, () => _model= value, _model, value); }
        }
    
        private IEnumerable<Person> _allowedDrivers;
        public IEnumerable<Person> AllowedDrivers
        {
            get { return _allowedDrivers; }
            set { this.Update(x => x.AllowedDrivers, () => _allowedDrivers=value, _allowedDrivers, value); }
        }
    }
