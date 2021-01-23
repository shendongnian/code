    class GenericsExample<T>{
            
        private T _value { get; set; }
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        
    }
