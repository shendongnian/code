    public class B : A
    {
       public override string GetName()
       {
           return "NameChange";
       }
       protected override void SomeMethod()
       {
           throw new NotImplementedException();
       }
    }
