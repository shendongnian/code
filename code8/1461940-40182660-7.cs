    public class PerformanceViewModel
    {
        [Required]
        public DateTime PerformanceDate { get; set; }
        [Required]
        public string PerformerName { get; set; }
        // ...
        public IEnumerable<WorksPerformedViewModel> WorksPerformedCollection { get; set; }
    }
    public class WorksPerformedViewModel
    {
        public bool WorkCover { get; set; }
        public string WorkTitle { get; set; }
        public string WorkComposers { get; set; }
        public int? Performances { get; set; }
        public TimeSpan? Duration { get; set; }
    } 
