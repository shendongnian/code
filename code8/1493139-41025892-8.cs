    public class GameObject : EntityData
    {
        public string PlayerId { get; set; }
        public virtual Player player { get; set; }
    }
    
     public class Player : EntityData
     {
        public string FirstName { get; set; }
        public string LastName { get; set; }
     }
