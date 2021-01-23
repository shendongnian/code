    public class baseClass
    {
      public dateTime dateCreated { get; protected set; } 
      protected baseClass() {
        dateCreated = DateTime.Now;
      }
    }
    
    public class derivedClas : baseClass
    {
      public derivedClass() : base()
      {
       //Do some constructor stuff for derivedClass if needed
      }
    }
