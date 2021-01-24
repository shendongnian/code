     public override bool Equals(object obj) {
       // Easy tests: 
       // 1. If "this" and "obj" are in fact just the same reference?
       // 2. Since `Node` (or Equals) is not sealed, the safiest is to check types 
       if (object.ReferenceEquals(this, obj))
         return true;
       else if (null == obj || other.GetType() != GetType()) 
         return false;
       // Potentially time/resource cosuming (we don't know IInterface implementation)
       return ((Node) obj).myInterface == myInterface;
     }
