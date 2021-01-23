    namespace LesRooster.Models
    {
        public class JsonGroup
        {
            public string Error { get; set; }
            public Result Result { get; set; }
            public string Id { get; set; }
    
        }
    
        public class Result {
            public IDictionary<string, Activities> Activities {get; set;}
            public int JsonCode {get; set;}
        }        
    
        public class Activities
        {
            public int ActivityId { get; set; }
            public string ActivityIdName { get; set; }
            public IDictionary<string, Schedule> Schedule { get; set; }
        }
    
        public class Schedule
        {
            public int Available { get; set; }
            public DateTime Start { get; set; }
        }    
    }
