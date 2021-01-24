    namespace MVCLogin.Models
    {
        public class TimeEntry
        {
            public int TimeEntryID { get; set; }
            public int TaskTypeID { get; set; }
            [ForeignKey("TaskTypeID")]
            public virtual TaskType TaskType { get; set; }
            public IEnumerable<SelectListItem> TaskTypeSelectListItems { get; set; }
            public double MonHours { get; set; }
            public double TueHours { get; set; }
            public double WedHours { get; set; }
            public double ThuHours { get; set; }
            public double FriHours { get; set; }
    
        }
    }
