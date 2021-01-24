    public class FooEntity
    {
       public int ID {get; set;}
       public string Name {get; set;}
       [NotMapped]
       public int Age { set; get; }
    }
