    var found = dbContext.Students
        .Where(e=>e.StudentID = targetId)
        .Select(e=> new 
         {
             e.StudentID,
             e.Password,
             e.Session.SessionName,
             e.Program.ProgramName
         }).FirestOrDefault();
