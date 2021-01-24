    public class User
    {
        public int Id { get; set; }
    }
    
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        [ForeignKey("CreatedBy")]
        public int UserId { get; set; }
        public User CreatedBy { get; set; }
    }
    context.Cards.Add(new Card
    {
        Name = "Card of Water",
        UserId = CurrentUser.Id,
        CreatedBy = CurrentUser
    });
    context.SaveChanges();
