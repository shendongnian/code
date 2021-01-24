    class Student
    {
        // This lock object is used to ensure we don't 
        // assign the same Id to more than one student
        private static readonly object IdLocker = new object();
        // This keeps track of next available student Id
        private static int nextStudentId;
        // Read only
        public int StudentId { get; }
        public string Name { get; set; }
        // Default constructor automatically sets the student Id
        public Student()
        {
            lock (IdLocker)
            {
                // Assign student id and incrment the next avaialable
                StudentId = nextStudentId;
                nextStudentId++;
            }
        }
        public static Student CreateFrom(Student student)
        {
            return new Student { Name = student.Name };
        }
        public override string ToString()
        {
            return $"Student {StudentId}: {Name}";
        }
    }
