    public sealed class OffDelay : IOffDelay
    {
        public bool Input
        {
            get { lock (locker) return _input; }
            set
            {
                lock (locker)
                {
                    if (value == _input)
                        return;
    
                    _input = value;
                    _lastInput = DateTime.UtcNow;
                }
            }
        }
        private bool _input;
    
        public bool Output
        {
            get { lock (locker) return (DateTime.UtcNOw - _lastInput).TotalSeconds < 1; }
        }
        private DateTime _lastInput;
    }
