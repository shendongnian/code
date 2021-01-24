        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                if (SetValue(ref _duration, value))
                {
                    StopTime = StartTime + _duration;
                    FromTo = CalculateFromTo();
                }
            }
        }
        private string CalculateFromTo()
        {
            return $"{StartTime:t} - {StopTime:t}";
        }
        private string _fromTo;
        public string FromTo
        {
            get => _fromTo;
            private set => SetValue(ref _fromTo, value);
        }
