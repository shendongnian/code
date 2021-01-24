    public abstract class BaseUIObject<T> where T : BaseObject
    {
       public T someObject {get; private set;}
       public void Setup(T baseObject)
       { 
           this.baseObject = baseObject; 
       }
    }
