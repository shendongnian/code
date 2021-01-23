    var userQuery = TimeEntries
      .Where (te => te.DateEntity.Month == DateTime.Today.Month && te.DateEntity.Year == DateTime.Today.Year)
      .Select(timeEntry => 
        new {
          UserName = timeEntry.User.FirstName + " " + timeEntry.User.LastName,
          HoursEntered = timeEntry.HoursEntered,       
          User = timeEntry.User
        }
      );
