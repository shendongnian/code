        public partial class AdviceLineCall
    {
      .
      .
      .
        [Required(ErrorMessage = "Subject Matter is required")]
        [DisplayName("Subject Matter")]
        public int? AdviceLineCallSubjectMatterID { get; set; }
      .
      .
      .
    }
    public partial class AdviceLineCallSubjectMatter
    {
        public AdviceLineCallSubjectMatter()
        {
            AdviceLineCalls = new HashSet<AdviceLineCall>();
        }
        [DisplayName("Subject Matter")]
        public int AdviceLineCallSubjectMatterID { get; set; }
        [StringLength(3)]
        [DisplayName("Subject Matter")]
        public string AdviceLineCallSubjectMatterDesc { get; set; }
        public virtual ICollection<AdviceLineCall> AdviceLineCalls { get; set; }
    }
