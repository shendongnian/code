    public abstract class MyAbstractObject<Tobj> where TObj: MyAbstractObject, new()
    {
        public static MyAbstractObject CreateObject()
        {
            Tobj subOb = new TObj();
            MyAbstractObject parent = subOb.ToObject();
            return parent;
        }
        public virtual TObj ToObject()
        {
            return CreateObject();
        }
    }
    
    public class ObjectD : MyAbstractObject<ObjectC> { }
    public class ObjectC : MyAbstractObject<ObjectB> { }
    public class ObjectB : MyAbstractObject<ObjectA> { }
    public class ObjectA : MyAbstractObject<ObjectA>
    {
        public override TObj ToObject()
        {
            return this;
        }
    }
    
    static void Main()
    {
        ObjectA a = ObjectD.CreateObject();
    }
