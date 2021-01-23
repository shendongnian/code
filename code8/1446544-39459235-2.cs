    class Building : IUserRelated
    {
        [Key]
        public Guid Id { get; set; }
    
        public string Location { get; set; }
        public Guid UserId { get; set; }
    }
