    // An abstract class for shared code
    abstract class WrapperClassWS
    {
        private abstract WebSvc1Root _Root { get; }
        
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
    class WrapperClassWS1 : WrapperClassWS
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
    class WrapperClassWS1 : WrapperClassWS
    {
        override WebSvc1Root _Root 
        { 
            get 
            { 
                return ...; // return root for this namespace
            } 
        }        
    }
