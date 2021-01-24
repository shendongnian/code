        public class EstimationActivity
    {
        public Guid Id { get; set; }
        public Guid EstimateId { get; set; }
        public virtual Estimate Estimate { get; set; }
        public Guid ParentActivityId { get; set; }
        [ForeignKey("ParentActivityId")]
        public virtual Activity ParentActivity { get; set; }
        public Guid ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }
        public double Duration { get; set; }
        [Range(minimum: 0, maximum: 100)]
        public int Contingency { get; set; }
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
    public class Activity
    {
        public Guid Id { get; set; }
        public Guid ActivityTypeId { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public Guid RfcAreaId { get; set; }
        public virtual RfcArea RfcArea { get; set; }
        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 5)]
        public string Name { get; set; }
        [InverseProperty("ParentActivity")]
        public virtual EstimationActivity EstimationParentActivity { get; set; }
        [InverseProperty("Activity")]
        public virtual EstimationActivity EstimationActivity { get; set; }
    }
