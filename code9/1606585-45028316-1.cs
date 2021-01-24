    public class Report
    { 
        public string Message{get;set;}
        public string Status{get;set;}
        public int Progress{get;set;}
        //Why not?
        public Color MessageColor{get;set;}
        Report(string message,string status, int progress, Color color)
        {
        ...
        }
    }
