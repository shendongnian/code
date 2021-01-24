    using(var ctx = new SchoolContext())
    {
        // create the *NEW* Student
        Student stu = new Student() { Name = "Riya" };
		
        // get existing subject with Id=202
        Subject sub = ctx.Subjects.FirstOrDefault(s => s.SubjectId == 202);
        // Add this existing subject to the new student's "Subjects" collection
        stu.Subjects.Add(sub);
		
		// Add the new student to the context, and save it all.
        ctx.Students.Add(stu);           
    
        ctx.SaveChanges();
    }
