    public interface IInterface
    {
        int MyMember { get; }
    }
    public class Class : IInterface
    {
        public string MyMember => "foo";
        int IInterface.MyMember => 2;
    }
