    public static Student findOrAdd(ModelSchool modelSchool,Student student)
    {
        var newStudent = modelSchool.Students.FirstOrDefault(s => s.Name == student.Name);
        if (newStudent == null)
        {
            newStudent = modelSchool.Students.Add(student);
            modelSchool.SaveChanges();
        }
        return newStudent;
    }
