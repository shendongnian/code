    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Group Name")]
        [Required]
        public string GroupName { get; set; }
        [ForeignKey("ProjectId")]
        [Required]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
