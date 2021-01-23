    public class YourClass
    {
          public YourClass(IJeep jeep)
          {
              Jeep = jeep;
          }
    
          private IJeep Jeep { get; }
          public void DoStuff()
          {
               Jeep.Rename(new JeepArgs());
          }
    }
