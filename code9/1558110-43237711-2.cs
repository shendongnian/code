    // An abstract class for shared code
    abstract class WrapperClassWS<T> // T enables generics on your abstract class
    {
        private abstract T _Root { get; } // _Root is now of type 'T' (a generic type)
        
        public MyNonWSobj GetObjectByName(string WhichName)
        {
            // ...
        }
        
        private CommonObj GetWSObjectByName(string WhichName)
        {
            // ...
        }
    }
    // Implementation of WS1 wrapper
    class WrapperClassWS1 : WrapperClassWS<WebSvc1Root>
    {
        override WebSvc1Root _Root 
        { 
            get 
            { 
                return ...; // return root for this namespace
            } 
        }        
    }
    // Implementation of WS2 wrapper
    class WrapperClassWS1 : WrapperClassWS<WebSvc2Root>
    {
        override WebSvc2Root _Root 
        { 
            get 
            { 
                return ...; // return root for this namespace
            } 
        }        
    }
