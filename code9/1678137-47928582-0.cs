    enum CommandStatus
    {
        def = 0,
        success = 1,
        A = 2,
        B = 3,
        ...
    }
    public class AuditLogs
    {
        public string user_id { get; set; }
        public CommandStatus command_status_code { get; set; }
    }
