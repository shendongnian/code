     public class Constituent{
                
       public string Name {get; set;} //This is a property, 
    
       public string Name //This is a property, The value can only be of type **string** because we've assigned it that datatype, which would also be the return type.
       {
         get { return _name; }
         set { _name = value; }
         }
       }
