    foreach (var student in Student)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                Student student = new Student...
    
                 foreach(var subjectInfo in subjectsInfo)
                 {
                     try
                     {
                       ... code omitted for clarity
                     }     
                     Catch(Exception ex)
                     {
                      // catch exception
    
                     }
                 }
            }
    
            Catch(Exception ex)
            {
    
            }
        } 
    }
