    Lazy Loading
    public virtual ICollection<TimeEntry> TimeEntries { get; set; }
    Or
    Eager Loading
    Week SelectedWeek = db.Weeks.Include("TimeEntries").Where(w => w.WeekId == 1).FirstOrDefault();
    Or 
    Explicit Loading
    var selectedWeek = db.Weeks.Find(1); 
     
    // Load the TimeEntries related to a given Week
    context.Entry(selectedWeek ).Collection(t => t.TimeEntries).Load();
 
