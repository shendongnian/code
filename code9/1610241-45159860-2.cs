    IEnumerable<Student> GetStudentsOfTeacher(string teacherCode)
    {
        return myDbContext.Students
           .Where(student => student.Teacher.TeacherCode == teacherCode);
    }
