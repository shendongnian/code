    public class Foo
    {
         public DateTime dateOfBirth
         {
             get{ return Age.dateOfBirth; }
             set{ Age.dateOfBirth = value; }
         }
         private readonly Age _age = new Age();
         public Age Age { get{  return _age; } }
    }
