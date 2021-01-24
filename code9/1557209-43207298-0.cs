    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("FavoriteCourseId")]
        public Course FavoriteCourse { get; set; }
        public int? FavoriteCourseId { get; set; }
    }
