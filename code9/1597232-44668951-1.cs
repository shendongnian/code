    public class LectureCompletion
    {
        [Key] // Defined only once
        public LectureCompletionId { get;set; }
        
        // Not needed if Lecture class has the primary key property of LectureId,
        // which is your case.
        [ForeignKey("Lecture")] // Name of your navigation property below.
        public int LectureId { get;set; }
        public Lecture Lecture { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserId {get;set;}
        public ApplicationUser ApplicationUser { get; set; }
        public bool Completed { get; set; }
    }
