    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RefIndicator { get; set; }
        public Team TeamCategory { get; set; }
        public byte TeamId { get; set; }
        public bool IsRegistered { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime? LastModified { get; set; }
        public UserRoles UserRoles { get; set; }
        public byte UserRolesId { get; set; }
    }
