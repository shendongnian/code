    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
    }
    
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students{ get; set; }
    }
    
    var students = DbContext.Students.Include(x => x.ClassRoom)
                                     .ToList();
