    using System.ComponentModel.DataAnnotations.Schema;
    public class Parent {
       // ...
       [NotMapped]
       public List<Child> Children { get; set; }
    }
