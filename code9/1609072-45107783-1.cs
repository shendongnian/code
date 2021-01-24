    var recentMeetingRowQuery = 
           from meeting in db.MeetingDetails.Where(m => m.GroupID == ID)
           join employee in db.Employees on meeting.PartnerID equals employee.ID 
           select new {
               Date = meeting.MeetingDate,
               Category = meeting.Category.Name,
               Partner = employee.LastName
           };
