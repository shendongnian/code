    var students = from s in studentRepository.GetStudents()
                   select s;
    
     if(!User.IsInRole("Admin"))
     {
         var loggedInStudentId = User.Identity.GetUserId();
         students = students.Where(x=>x.StudentId = loggedInStudentId);
     }          
