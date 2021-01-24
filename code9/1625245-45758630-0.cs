    class Results
        {
            public string id { get; set; }
            public int count { get; set; }
            public bool feasible { get; set; }
            public Dictionary<string, RouteResult> route { get; set; }
        }
      public class RouteResult
        {
            public string index { get; set; }
            public string name { get; set; }
            public int arrival { get; set; }
            public double distance { get; set; }
        }
