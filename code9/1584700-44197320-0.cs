    public partial class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    {
        public decimal Balance { get; set; }
        public string NickName { get; set; }
        public int AnotherEntityId { get; set; }
        
        [ForeignKey("AnotherEntityId ")]
        public virtual AnotherEntity AnotherEntity { get; set; }
        public User()
        {
            Id = Guid.NewGuid();
        }
    }`
