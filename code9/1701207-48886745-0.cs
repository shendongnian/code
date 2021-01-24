    // groupjoin teachers and students:
    var result = context.Teachers.GroupJoin(context.Students, 
        teacher => teacher.Id,             // from each Teacher take the Id
        student => student.TeacherId,      // from each Student take the teacherId
        // when they match, group the teacher and all his matching students:
        (teacher, students) => new 
        {                          // make a new object:
                                   // get some Teacher properties
             Name = Teacher.Name,
             AddrLine1 = Teacher.AddrLine1,
             ...
             // make a table from the columns from all the Teacher's students:
             Table2 = students 
                .Select(student => new
                {
                    Col1 = student.Col1,
                    Col2 = student.Col2,
                })      
                // here it is clearly to see that Col1 comes from Student
                // oops, not all students, only those wish ABC for Col1
                .Where(studentColumns => studentColumns.Col1.Equals("ABC"));
