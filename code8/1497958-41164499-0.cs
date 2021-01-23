    [Table("COURSE_INSTANCE")]
    public class BIZCourseInstanceEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UI_ID { get; set; }
        ...
    }
