    public class ReadOnlyField<T>
    {
        private bool _frozen;
        private T _value;
        
        public T Value
        {
            get { return _value; }
            set
            { 
                if (_frozen)
                    throw new InvalidOperationException();
                _value = value;
            }
        }
        public void Freeze()
        {
            _frozen = true;
        }
    }
