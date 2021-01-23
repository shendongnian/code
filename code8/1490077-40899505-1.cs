    public sealed class PublicClass
    {
        private PrivateClass privateClass;
    
        public PublicClass()
        {
            //inaccessible due to protection level.
            this.privateClass = new PrivateClass(); 
            //works!
            this.privateClass = PrivateClass.GetInstance();
        }
    
        private sealed class PrivateClass
        {
            private PrivateClass()
            {
            }
            public static PrivateClass GetInstance()
            {
             return new PrivateClass();
            }
        }
    }
