    public abstract class IA
    {
      public bool value;
      public virtual void ChangePropertyOfAIChild()
      {
        value = true;
      }
    }
    public class B : IA
    { }
    public class C : IA
    { }
    // in main
    IA newBInstance = new B();
    newBInstance.ChangePropertyOfAIChild();
    IA newCInstance = new C();
    newCInstance.ChangePropertyOfAIChild();
    ///
