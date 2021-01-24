    public abstract class BaseCommandType<T>
    {
        public abstract TaskCompletionSource<T> Tcs { get; }
    }
    public class CommandType1 : BaseCommandType<CommandType1>
    {
    }
    public class CommandType2 : BaseCommandType<CommandType2>
    {
    }
    public Task<T> SendCommand<T>(T type) where T : BaseCommandType<T>
    {
        return type.Tcs.Task;
    }
