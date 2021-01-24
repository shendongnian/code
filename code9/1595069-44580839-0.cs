    public class User
    {
        [Key]
        public int Id { get; set; }         // primary key
    }
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        [ForeignKey("CreatedBy")]
        public int UserId { get; set; } // Foreign Key
    
        public virtual User CreatedBy { get; set; }
        //use virtual keyword to allow lazy loading while execution
    }
    
    context.Cards.Add(new Card
    {
        Name = "Card of Water",
        UserId = CurrentUser.Id
        //No need to insert CreatedBy user object here as we are passing UserId
    });
    context.SaveChanges();
