    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IHelloWorld
    { 
        string HelloUser(string name);
    }
    [ComVisible(true)]
    [ComDefaultInterface(typeof(IHelloWorld))]
    public class HelloWorld : IHelloWorld
    {
        public string HelloUser(string name)
        {
            return $"Hello, {name}.";
        }
    }
