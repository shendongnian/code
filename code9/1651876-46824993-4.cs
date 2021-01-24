    public abstract class BaseUIObject<T> where T : BaseObject
    {
       public T theObject {get; private set;}
       public void Setup(T baseObject)
       { 
           this.theObject = baseObject; 
       }
    }
