    public abstract class ShippableEntity
    {
        private Address _Address;
        private ShippableEntity(Address address)
        {
            _Address = address;
        }
        public abstract void Print();
        public Address ShippingAddress { get { return _Address; } }
    }
