    foreach (var student in Student)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                Student student = new Student...
    
                int numSuccesses = 0;
                 foreach(var subjectInfo in subjectsInfo)
                 {
                     try
                     {
                       ... code omitted for clarity
                       numSuccesses++; // The very last thing you do
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
