    public class Student
    {
        public int StudentId { get; set; }
        public LevelId {get; set;}
    
        public string Name { get; set; }
        [ForeignKey("LevelId")]
        public Level Level { get; set; }
    }
