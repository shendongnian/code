    public class A {
      public virtual void Accept(Visitor visitor)
      {
        visitor.Visit(this);
      }
      public A AsBase() 
      {
         return this;
      }
    }
