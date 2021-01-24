    public class Person
    {   
       [Key]
       public int PersonId {get;set;}
    
       [ForeignKey("Player")]
       public int player {get;set;} // make this int? if a person can optionally be a player
    
       public virtual Player {get;set;}
       ...
    }
