    class uPermissions {
       public T GetAllowedOrCount<T>(string index) {
         get {
           if (typeof(T) == typeof(bool) {
             return permissions.Where (p => p.name == index).First ().allowed;
           } else if (typeof(T) == typeof(int) {
             return constraints.Where (c => c.name == index).First ().count;
           }
           throw new InvalidOperationException("only bool and int are supported");
         }
    }
