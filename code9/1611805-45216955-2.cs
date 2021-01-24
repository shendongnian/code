    public class StudentCourse
    {
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
