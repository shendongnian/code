    public class CompositeKeyModel
    {
       [Key]
       public string Name { get; set; }
       [Key]
       public string Group { get; set; }
       public string CompositeKey {get
       {
          return Name+Group
       }}
    }
