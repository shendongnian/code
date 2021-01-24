    [ThriftStruct]
    public class LogEntry
    {
        [ThriftConstructor]
        public LogEntry([ThriftField(1)]String category, [ThriftField(2)]String message)
        {
            this.Category = category;
            this.Message = message;
        }
        [ThriftField(1)]
        public String Category { get; }
        [ThriftField(2)]
        public String Message { get; }
    }  
    [ThriftService("scribe")]
    public interface IScribe
    {
        [ThriftMethod("getMessages")]
        List<LogEntry> GetMessages();
        [ThriftMethod]
        ResultCode Log(List<LogEntry> messages);
    }
    public class Scribe : IScribe
    {
        public List<LogEntry> GetMessages()
        {
            return new List<LogEntry>
            {
                new LogEntry { Category = "c1", Message = Guid.NewGuid().ToString() },
                new LogEntry { Category = "c2", Message = Guid.NewGuid().ToString() },
                new LogEntry { Category = "c3", Message = Guid.NewGuid().ToString() }
            };
        }
        public ResultCode Log(List<LogEntry> messages)
        {
            return ResultCode.TRY_LATER;
        }
    }
