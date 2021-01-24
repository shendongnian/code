    public class Car : ModelBase
    {
        ...
        private ICollection<Person> _allowedDrivers;
        public ICollection<Person> AllowedDrivers
        {
            get { return _allowedDrivers; }
            set { this.Update(x => x.AllowedDrivers, () => _allowedDrivers=value, _allowedDrivers, value); }
        }
    }
