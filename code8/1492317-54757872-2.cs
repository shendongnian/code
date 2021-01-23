    class AnotherClass 
    {
        public string value1 {get; set;}
        public int value2 {get; set;}
    }
    
    // Controller code
    // Dictionary should has key which became key in resulting object
    Dictionary<string, AnotherClass> result = // Init dictionary 
    return new JsonResult(result);
