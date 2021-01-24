    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ClassRoomId { get; set; }
        // public virtual ClassRoom ClassRoom { get; set; }
    }
    
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // public virtual ICollection<Student> Students{ get; set; }
    }
    public class StudentToClassRoom
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
    }
    
    // var students = DbContext.Students.Include(x => x.ClassRoom).ToList();
    var mergedRecords = DbContext.StudentToClassRoom
                                 .Include(x => x.Student)
                                 .Include(x => x.ClassRoom)
                                 .ToList()
