    [Flags]
    public enum Status
    {
        Unknown = 0,
        Completed = 1,
        Blocked = 2,
        Phase1 = 4,
        Phase2 = 8,
        Phase3 = 16,
        Closed = 32
    }
    
    public class Request
    {        
        public string Name { get; set; }
        public string StatusText { get { return GetStatusText(); } }
        public Status Status { get; set; }
    
        public Request()
        {
            this.Status = Status.Unknown;
        }
    
        private string GetStatusText()
        {
            string statusText = "Created";
    
            if (AnyStatus(Status.Closed | Status.Completed))
            {
                statusText = IsStatus(Status.Closed) ? "Closed" : "Completed";
            }
            else
            {
                if (IsStatus(Status.Blocked))
                {
                    statusText = "Blocked";
                }
                else
                {
                    if(IsStatus(Status.Phase3)) {
                        statusText = "Phase 3";
                    }
                    else if(IsStatus(Status.Phase2)) {
                        statusText = "Phase 2";
                    }
                    else if (IsStatus(Status.Phase1))
                    {
                        statusText = "Phase 1";
                    }
                }
            }
    
            return statusText;
        }
    
        private bool IsStatus(Status checkStatus)
        {
            return ((this.Status & checkStatus) == checkStatus);
        }
    
        private bool AnyStatus(Status checkStatus)
        {
            return ((this.Status & checkStatus) > 0);
        }
    }
