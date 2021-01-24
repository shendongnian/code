        private bool _IsDataAvailable =false;
        public bool GetIsDataAvailable()
        {
            return _IsDataAvailable;
        }
        public void SetIsDataAvailable([DefaultParameterValue(false)] bool b)
        {
            _IsDataAvailable = b;
        }
