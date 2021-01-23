    DateTime today = DateTime.Today;
    var userQuery = 
    from timeEntry in TimeEntries
    where timeEntry.DateEntity.Month == today.Month && timeEntry.DateEntity.Year == today.Year
    select new {
        UserName = timeEntry.User.FirstName + " " +timeEntry.User.LastName,
        HoursEntered = timeEntry.HoursEntered,       
        User = timeEntry.User
    };
