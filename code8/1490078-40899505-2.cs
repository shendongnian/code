    public sealed class PublicClass
    {
        // this is private, but public class has access to it
        private PrivateClass privateClass;
    
        public PublicClass()
        {
          // can't be called, privateClass's ctor/method is private
          // privateClass = newPrivateClass();
          // can be called, this static method is public
          privateClass = PrivateClass.GetInstance();
          // can't be called, it's private
          // privateClass.DoWork();
        }
    
        // this is private, but public class has access to it
        private sealed class PrivateClass
        {
          
            private PrivateClass()
            {
            }
            public static PrivateClass GetInstance()
            {
              // can be called within the class itself, it has
              // access to private's (method, fields, properties, ctors)
              return new PrivateClass();
            }
            private void DoWork() { }
        }
    }
