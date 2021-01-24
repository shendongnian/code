    public class Action
    {
       [Key]
       public Guid ActionId { get; set; }
       // ...
       public Guid GrantedToId { get; set; }
       [ForeignKey("GrantedToId")]
       public virtual User GrantedTo { get; set; }
       // ...
    }
