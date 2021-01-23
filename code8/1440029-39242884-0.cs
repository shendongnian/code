    struct DogWrapper : IEquatable<DogWrapper>
    {
        readonly Dog _value;
        public Dog Value
        {
            get
            {
                if (_value == null)
                {
                    throw new DogDoesNotExistException();
                }
                return _value;
            }
        }
        public DogWrapper(Dog value)
        {
            _value = value;
        }
        // TODO 
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
        public bool Equals(DogWrapper other)
        {
            throw new NotImplementedException();
        }
        public static implicit operator DogWrapper(Dog value)
        {
            return new DogWrapper(value);
        }
    }
