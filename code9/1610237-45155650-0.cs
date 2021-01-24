    var st = (from tt in context.Teachers
              where tt.TypeID == 2
              join ss in context.Students
              on tt.ID equals ss.teacherID into ssj
              select new Test {
                  Id = tt.ID,
                  Text = tt.Text,
                  Students = (from ss in ssj
                              select new StudentsDTO() {
                                  Name = ss.Name,
                                  Id = ss.StudentID
                               }.ToList()
              }).ToList();
    return st;
