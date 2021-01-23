    public interface IHandler
    {
        object Process(IProcess process);
    }
    
    public class BoolHandler : IHandler
    {
        object Process(IProcess process){ return true;}
    }
