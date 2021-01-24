    class Supplier
    {
        private string _Address;
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                if (_Address != value)
                {
                    _Address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
    }
    class SupplierIsDirtyTracker
    {
        private Dictionary<string, object> _originalPropertyValues = new Dictionary<string, object>();
        private Supplier _supplier;
        public void Track(Supplier supplier)
        {
            _supplier = supplier;
            _originalPropertyValues.Add(nameof(Supplier.Address), supplier.Address);
        }
        public bool HasChanges()
        {
            return !Equals(_originalPropertyValues[nameof(Supplier.Address)], _supplier.Address);
        }
        public IEnumerable<string> GetChangedPropertyNames()
        {
            if(!Equals(_originalPropertyValues[nameof(Supplier.Address)], _supplier.Address))
            {
                yield return nameof(Supplier.Address);
            }
        }
    }
