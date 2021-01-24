    class DayCollection
    {
        private Dictionary<string, string> _dayList = new Dictionary<string, string>();
        public string this [string day]
        {
            get { return _dayList[day;}
            set { _dayList[day] = value; }
        }
    }
    class ClassY
    {
        public DayCollection Days  = new DayCollection();
    }
