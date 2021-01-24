    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public static Student CreateFrom(Student student)
        {
            return new Student { StudentId = student.StudentId, Name = student.Name };
        }
    }
