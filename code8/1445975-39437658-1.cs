    public class WorkItem
    {
        // on this day...
        public DateTime Date { get; set; }
        // do work for these days:
        public List<DateTime> Tasks { get; private set; }
    
        public WorkItem(DateTime d)
        {
            Date = d.Date;
            Tasks = new List<DateTime>();
        }
    
        public void AddDay(DateTime dt)
        {
            if (!Tasks.Contains(dt.Date))
                Tasks.Add(dt.Date);
        }
    }
