    class DayCollection
    {
        private Dictionary<string, string> _dayList = new Dictionary<string, string>();
        public string mon
        {
            get { return this["mon"]; }
            set { this["mon"] = value; }
        }
        public string mon
        {
            get { return this["mon"]; }
            set { this["mon"] = value; }
        }
        public string tue
        {
            get { return this["tue"]; }
            set { this["tue"] = value; }
        }
        public string wed
        {
            get { return this["wed"]; }
            set { this["wed"] = value; }
        }
        public string thu
        {
            get { return this["thu"]; }
            set { this["thu"] = value; }
        }
        public string fri
        {
            get { return this["fri"]; }
            set { this["fri"] = value; }
        }
        public string sat
        {
            get { return this["sat"]; }
            set { this["sat"] = value; }
        }
        public string sun
        {
            get { return this["sun"]; }
            set { this["sun"] = value; }
        }
        public string this[string day]
        {
            get { return _dayList[day;}
            set { _dayList[day] = value; }
        }
    }
