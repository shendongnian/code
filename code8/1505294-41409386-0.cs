    public class Field<T> : Field
    {
       T _value;
       //specific interface implementation
       object Field.Value
       {
         get
         {
            return _value;
         }
       }
       public T Value
       {
          get
          {
             return _value;
          }
       }
    }
