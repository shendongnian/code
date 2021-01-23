        public class Settings
        {
            public List<Task> Tasks { get; set; }
        }
        public class Task
        {
            [XmlAttribute]
            public int ID { get; set; }
            [XmlAttribute]
            public string Name { get; set; }
            public List<Schedule> Schedules { get; set; }
        }
        public class Schedule
        {
            [XmlAttribute]
            public string OnlyUntilFirstSuccess { get; set; }
            public List<DayOfWeek> Days { get; set; }
            public Frequency Frequency { get; set; }
        }
        public class Frequency
        {
            public Interval Interval { get; set; }
        }
        public class Interval
        {
            [XmlAttribute]
            public string StartTime { get; set; }
            [XmlAttribute]
            public string EndTime { get; set; }
            [XmlAttribute]
            public int EveryMins { get; set; }
        }
