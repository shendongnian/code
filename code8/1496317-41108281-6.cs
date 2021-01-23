    public class BaseClass{
     
     public virtual BaseClass Clone(){
       
       return new BaseClass();
       
     }
     
    }
    
    public class MyClass : BaseClass{
     
     public override BaseClass Clone(){
       
       return new MyClass();
       
     }
     
    }
    ...
    
    BaseClass myClone=thatObject.Clone();
