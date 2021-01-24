    public class ItemVersion : ITenantSecurityPolicy
    {
        [Key,Column(Order=0)]
        public int TenantId { get; set; }
        [Key,Column(Order=1),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CreatedPersonId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
     
    }
