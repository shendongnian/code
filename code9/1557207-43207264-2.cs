    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    
        public Course FavoriteCourse { get; set; }
        public int? FavoriteCourseID { get; set; }
    }
    
    public class Class
    {
        [Key]
        [ForeignKey("Student")]
        public int ID { get; set; }
        public string Name { get; set; }
    	
    	public virtual Student Student { get; set; }
    }
