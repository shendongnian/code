    public class Supervisor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public virtual ICollection<SupervisorStudents> Students { get; set; }
    }
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string MatricNo { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SupervisorStudents> Supervisors { get; set; }
    }
    public class SupervisorStudents
    {
        [Key, Column(Order = 0)]
        public int SupervisorId { get; set; }
        [ForeignKey(nameof(SupervisorId))]
        public Supervisor Supervisor { get; set; }
        [Key, Column(Order = 1)]
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        public string TagMainOrCo { get; set; }
    }
