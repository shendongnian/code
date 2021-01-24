    public void AddCoursesToStudent(int studentId, List<int> coursesIds)
    {
        using (var context = new SchoolDBContext())
        {
            var student = context.Students.Find(studentId);
            AddCoursesToStudent(context, student, coursesIds);
        }
    }
