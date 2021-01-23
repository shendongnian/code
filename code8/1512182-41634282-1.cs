      public abstract class BaseObject { 
            //even though this does not have abstract methods I declare it as abstract because I do not want it to be initialized
            ....
            public virtual void save(Connection con) {
               con.InsertOrReplace(this);
            }
            ....    }
    
       public abstract CheckedDataObject : BaseDataObject {
            ....
            public override void save(Connection con);    }
