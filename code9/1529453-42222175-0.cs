    public class Foo
    {
     public DateTime dateOfBirth {
         get { return Age.dateOfBirth; }
         set { Age.dateOfBirth = value; }
     }
     public Age age {get; set;}
     public Foo() { Age = new Age(); }
    }
