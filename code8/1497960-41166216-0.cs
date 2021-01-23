    [Table("COURSE_INSTANCE")]
    public class BIZCourseInstanceEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UI_ID { get; set; }
        [StringLength(255)]
        public string UnitInstanceCode { get; set; }
        [StringLength(255)]
        public string FESLongDescription { get; set; }
        [StringLength(255)]
        public string FESShortDescription { get; set; }
        [StringLength(255)]
        public string FullDescription { get; set; }
        [StringLength(255)]
        public string OwningOrganisationCode { get; set; }
        public int? OwningOrganisationID { get; set; }
        [StringLength(255)]
        public string TopicCode { get; set; }
        [StringLength(255)]
        public string UnitCategory { get; set; }
        [StringLength(255)]
        public string UnitCode { get; set; }
        [StringLength(50)]
        public string FESQualificationType { get; set; }
        public int? SCHOOLS { get; set; }
        public int? MARKETING_GROUPS { get; set; }
    }
