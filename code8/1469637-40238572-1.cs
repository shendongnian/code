     public class OutputTerminal
        {
            public string type { get; set; }
            public string id { get; set; }
            public string connectedId { get; set; }
            public string terminalType { get; set; }
            public string connectedType { get; set; }
        }
    
        public class Position
        {
            public string type { get; set; }
            public string x { get; set; }
            public string y { get; set; }
        }
    
        public class Item
        {
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string memberCount { get; set; }
            public IList<OutputTerminal> outputTerminals { get; set; }
            public Position position { get; set; }
            public string isFinished { get; set; }
            public string isRecurring { get; set; }
            public string segmentId { get; set; }
            public string waitFor { get; set; }
            public string testId { get; set; }
        }
    
        public class Root
        {
            public string type { get; set; }
            public string currentStatus { get; set; }
            public string id { get; set; }
            public IList<Item> items { get; set; }
        }
