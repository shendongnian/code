    public class SomeUIObject : BaseUIObject<SomeObject>
    {
         public void Setup(T someObject)
         { 
             base.Setup(someObject); 
             SomeUIObjectSpecificRoutine(); 
         }
        // rest of concrete class code...
    }
