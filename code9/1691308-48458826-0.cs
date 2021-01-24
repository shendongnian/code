       public class ClonableClass : ICloneable
       {
          public object Clone()
          {
             return this.MemberwiseClone();
          }
       }
