    var result = myDbContext.Teachers                // from the set of Teachers
        .Where(teacher => teacher.TypeId == 2)       // take all teachers with TypeId 2
        .Select(teacher => new Test                  // from every remaining Teacher,
        {                                            // create one Test object
            Id = teacher.Id,                         // With Id is Teach Id
            Text = teacher.Text,                     // Text is teacher.Text
            Students = teacher.Students              
                .Select(student => new StudentDTO    // from every Student of this Teacher
                {                                    // create a StudentDTO object
                    Id = student.ID,                 // with Id = student.Id
                    Name= student.Name,              // Name is student.Name
                })
                .ToList(),                           // create a list of these StudentDTOs
         })
         .ToList();                                  // create a list of all Test objects
