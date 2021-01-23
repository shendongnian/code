      public abstract class BaseObject
      {
         public virtual void Save(Connection con)
         {
             con.InsertOrReplace(this);
         }
      }
      public class Father : BaseObject
      {
          public override void Save()
          {
           // no checks needed?
           base.Save();
          }
      }
      public class Child : BaseObject
      {
        public override void Save()
        {
         //do checks here to see if it is correct, if not throw an exception
         base.Save();
        }
      }
