    public class RegisteredStudents  
     {
        public RegisteredStudents () {}
        [Key]
        public int RegisteredStudentsId { get; set; }
        [Index]
        public int YogaSpaceEventRefId { get; set; }
        [ForeignKey("YogaSpaceEventRefId")]
        public virtual YogaSpaceEvent YogaSpaceEvent { get; set; }
        public int StudentId { get; set; }
    }
