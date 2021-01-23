    public class Object
    {       
        // Returns a String which represents the object instance.  The default
        // for an object is to return the fully qualified name of the class.
        // 
        public virtual String ToString()
        {
            return GetType().ToString();
        }    
    }
