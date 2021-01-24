    public enum MethodType
    {
        T1,
        T2
    }
    
    public class TestRequest
    {
        public IRequest Method1(string token, int state)
        {
            // Some Code
            return new Request1();
        }
        public IRequest Method2(string token, int state, string name)
        {
            // Some Code
            return new Request2();
        }
    }
    public interface IRequest
    {
        string RequestName();
    }
    public class Request1 : IRequest
    {
        public string RequestName() => "Request1";
    }
    public class Request2 : IRequest
    {
        public string RequestName() => "Request2";
    }
