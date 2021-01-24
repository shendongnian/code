    namespace NUnitTestAbstract
    {
        public interface IServer { }
        
        public class BaseServer()
        {
            private IServer _server;
            public BaseServer(IServer server)
            {
                _server = server;
            }
            
            public IServer GetServerInstance()
            {
                return _server;
            }
        }
    
        public class SomeTests1 : ServerBase
        {
            // not overriding BaseTestClass1Method, child classes should do
            public void SomeTestMethodA() { }
    
            public void SomeTestMethodB() { }
        }
    
        public class SomeTests2 : ServerBase
        {
            // not overriding BaseTestClass1Method, child classes should do
            public void SomeTestMethodX() { }
    
            public void SomeTestMethodY() { }
        }
    }
    public class ServerA : IServer
    {
        //Implementation
    }
    public class ServerB : IServer
    {
        //Implementation
    }
