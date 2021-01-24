    class Activity {
        public Func<bool> Action { get; set; }
        public String FailureMessage { get; set; }
    }
    
    Activity[] actionChain = new[] {
        new Activity { Action = A1, FaulureMessage = "a1 failed"}
    ,   new Activity { Action = A2, FaulureMessage = "a2 failed"}
    ,   new Activity { Action = A3, FaulureMessage = "a3 failed"}
    };
