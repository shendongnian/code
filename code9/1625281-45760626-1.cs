    using(var ctx = new SchoolContext())
    {
        // create the *NEW* Student, and assign it an *EXISTING* SubjectId        
        Student stu = new Student() { Name = "Riya" };
        // get existing subject with Id=202
        Subject sub = ctx.Subjects.FirstOrDefault(s => s.SubjectId == 202);
        // set the student's Subject to the one you've just retrieved
        stu.Subject = sub;
        ctx.Students.Add(stu);           
    
        ctx.SaveChanges();
    }
