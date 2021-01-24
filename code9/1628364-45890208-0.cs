    public class NoInit
    {
        private bool _flag;
    }
    
    public class DefaultInit
    {
        private bool _flag = false;
    }
    
    public class NonDefaultInit
    {
        private bool _flag = true;
    }
    
    public class TestDefaultCtor
    {
        private bool _flag;
    
        public TestDefaultCtor()
        {
            _flag = false;
        }
    }
    
    
    public class TestNonDefaultCtor
    {
        private bool _flag;
    
        public TestNonDefaultCtor()
        {
            _flag = true;
        }
    }
