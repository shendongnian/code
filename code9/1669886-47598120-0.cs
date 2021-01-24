    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        // Other properties...
        [ForeignKey("User")]
        public int UserId{get; set;}
        public User User { get; set; }
    
        [ForeignKey("Restaurant ")]
        public int RestaurantId {get; set;}
        public Restaurant Restaurant { get; set; }
    }
