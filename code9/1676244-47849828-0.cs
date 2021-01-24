    public partial class Users : IHasId<int>
    {
        [AutoIncrement]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    
        [References(typeof(Roles))]
        [Required]
        public int RolesId { get; set; }
        
        [Reference]
        public Roles Roles { get; set; }
    }
    
    public partial class Roles : IHasId<int>
    {
        [AutoIncrement]
        public int Id { get; set; }
    
    	[Required]
        public string Name { get; set; }
    }
