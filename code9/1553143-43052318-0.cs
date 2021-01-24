    public partial class TeamMember
    {
        [Key]
        [Column(Order = 0)]
        public Guid TeamId { get; set; }
        [Key]
        [Column(Order = 1)]
        public Guid UserId { get; set; }
        [ForeignKey("TeamId")]
        public virtual MSUCTeam Team { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
