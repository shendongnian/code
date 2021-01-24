    class CoolerSystem
    {
        private CoolerFan[] _fans = new CoolerFan[5];
        private bool[] _coolerfanIsOn;
        public bool[] CoolerFanIsOn
        {
            get { return _coolerfanIsOn; }
            set
            {
                _coolerfanIsOn = value;
            }
        }
        public bool GetFanState(int number)
        {
            return CoolerFanIsOn[number];
        }
        public void SetFanState(int number, bool value)
        {
            CoolerFanIsOn[number] = value;
        }
    }
