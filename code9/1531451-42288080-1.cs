    // Deliberately use name that isn't valid C# to not clash with anything
    private class <CountToTen> : IEnumerator<int>, IEnumerable<int>
    {
        private int _i;
        private int _current;
        private int _state;
        private int _initialThreadId = CurrentManagedThreadId;
        
        public IEnumerator<CountToTen> GetEnumerator()
        {
            // Use self if never ran and same thread (so safe)
            // otherwise create a new object.
            if (_state != 0 || _initialThreadId != CurrentManagedThreadId)
            {
                return new <CountToTen>();
            }
            
            _state = 1;
            return this;
        }
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public int Current => _current;
        
        object IEnumerator.Current => Current;
        
        public bool MoveNext()
        {
            switch(_state)
            {
                case 1:
                    _i = 1;
                    _current = i;
                    _state = 2;
                    return true;
                case 2:
                    ++_i;
                    if (_i <= 10)
                    {
                        _current = _i;
                        return true;
                    }
                    break;
            }
            _state = -1;
            return false;
        }
        
        public void Dispose()
        {
          // if the yield-using method had a `using` it would
          // be translated into something happening here.
        }
        
        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
