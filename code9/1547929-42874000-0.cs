    public class TeamMember
    {
        public TeamMember()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        public string TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
        [Required]
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User Member { get; set; }
    }
