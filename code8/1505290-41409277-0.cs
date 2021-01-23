    public interface Field
    {
       object Value {get;}
    }
    public class MyField<T> : Field
    {
       public T _value;
       
       public T MyTypedValue
       {
           get 
           { 
               return _value; 
           }
       }
       public object Value
       {
           get
           {
              return _value;
           }
       }
    }
