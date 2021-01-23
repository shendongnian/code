    using System;
    using System.Dynamic;
    
    public class MyClass : Whatever, IDynamicMetaObjectProvider {
    
        // This 1 line is *ALL* you need to add support for all of the DynamicObject methods
        public DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression e)
            { return new MetaObject(e, this); }
    
        // Now, if you want to handle dynamic method calls, 
        // you can implement TryInvokeMember, just like you would in DynamicObject!
        public bool TryInvokeMember
           (InvokeMemberBinder binder, object[] args, out object result) {
            if (binder.Name.Contains("Cool")) {
                result = "You called a method with Cool in the name!";
                return true;
            } else {
                result = null;
                return false;
            }
        }
    }
