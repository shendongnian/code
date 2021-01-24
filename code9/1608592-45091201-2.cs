    public class YogaSpaceEvent
    {
        public YogaSpaceEvent() {}
        [Key]
        public int YogaSpaceEventId { get; set; }
        [Index]
        public int YogaSpaceRefId { get; set; }
        [ForeignKey("YogaSpaceRefId")]
        public virtual YogaSpace YogaSpace { get; set; }
        [Required]
        [Index]
        public DateTime EventDateTime { get; set; }
        [Required]
        public YogaTime Time { get; set; }
        [Required]
        public YogaSpaceDuration Duration { get; set; }
        public virtual ICollection<RegisteredStudents> RegisteredStudents { get; set; }
    }
