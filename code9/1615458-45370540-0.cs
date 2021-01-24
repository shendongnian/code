    class Address
    {
        public bool DoesntHaveAddress3or4 { get { return string.IsEmptyOrWhiteSpace(this.Address3) && string.IsEmptyOrWhiteSpace(this.Address4); } }
        public bool DoesntHaveAddress3 { get { return string.IsEmptyOrWhiteSpace(this.Address3); } }
    }
