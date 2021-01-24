    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Group Name")]
        [Required]
        public string GroupName { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
