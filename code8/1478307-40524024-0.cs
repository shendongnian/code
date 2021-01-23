     public class ScheduleModel
        {
            public List<Schedule> ScheduleList { get; set; }
        }
    
        public class Schedule
        {
            public int ScheduleId { get; set; }
            public string ScheduleName { get; set; }
            public List<Door> DoorList { get; set; }
        }
    
        public class Door
        {
            public int DoorId { get; set; }
            public string DoorName { get; set; }
        }
