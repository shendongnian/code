    public class LectureCompletion
    {
        [Key] // Defined only once
        public LectureCompletionId { get;set; }
        public Lecture LectureId { get; set; }
        public ApplicationUser UserId{ get; set; }
        public bool Completed { get; set; }
    }
