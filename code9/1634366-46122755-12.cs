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
        //Etc....
        public string this[string day]
        {
            get { return _dayList[day;}
            set { _dayList[day] = value; }
        }
    }
