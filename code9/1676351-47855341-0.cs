        public class GameTable
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id
        {
            get;
            set;
        }
    
        [Required]
        public string Name { get; set; }
    
        [Required]
        public string Description { get; set; }
    
        public Guid CreatorId { get; set; }
    
        [ForeignKey(nameof(CreatorId))]
        public Account Creator { get; set; }
    }
    
        public class Account
        {
        public Account()
        {
            Elo = 1000;
        }
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    
        [Required]
        [MaxLength(15)]
        [MinLength(4)]
        public string Name { get; set; }
    
        [Required]
        [MaxLength(32)]
        [MinLength(32)]
        public string PasswordHash { get; set; }
    
        public int Elo { get; set; }
    
        public bool IsAdmin { get; set; }
    
        public Guid? CurrentTableId { get; set; }
    
        [ForeignKey(nameof(CurrentTableId))]
        public virtual GameTable CurrentTable { get; set; }
        public virtual ICollection<GameTable> Children { get; set; }
        }
