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
    public class ObjectA : MyAbstractObject<ObjectB> { }
    public class ObjectB : MyAbstractObject<ObjectC> { }
    public class ObjectC : MyAbstractObject<ObjectD> { }
    public class ObjectD : MyAbstractObject<ObjectD>
    {
        public override TObj ToObject()
        {
            return this;
        }
    }
    
    static void Main()
    {
        ObjectA a = ObjectA.CreateObject();
    }
