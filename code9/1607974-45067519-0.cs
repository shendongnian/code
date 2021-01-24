    class RecurrenceModel
    {
        public RecurrenceModel()
        {
            GetType().GetProperty("Weekly" + DateTime.Today.DayOfWeek).SetValue(this, true);
        }
        public bool WeeklyMonday { get; set; }
        public bool WeeklyTuesday { get; set; }
        public bool WeeklyWednesday { get; set; }
        public bool WeeklyThursday { get; set; }
        public bool WeeklyFriday { get; set; }
        public bool WeeklySaturday { get; set; }
        public bool WeeklySunday { get; set; }
    }
