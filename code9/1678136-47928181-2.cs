    public class AuditLogsDetail 
        {
            public int CommandStatusCode { get; set; }
    
            public string CommandStatus
            {
                get
                {
                    switch (CommandStatusCode)
                    {
                        case 0:
                            return "Verify";
    
                        case 1:
                            return "Active";
                        // and so on for the other 12 cases                        
                        default:
                            // you could throw an exception here or return a specific string like "unknown"
                            throw new Exception("Invalid Command Status Code");
                    }
                }
            }
        }
