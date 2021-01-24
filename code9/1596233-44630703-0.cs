    class RootObject
    {
        string kind {get;set}
        Data data {get;set;}
        List<Child> {get;set;}
    }
    
    class Data
    {
        string modhash {get;set;}
        string before {get;set;}
        string after {get;set;}
    }
    
    class Child
    {
        string kind {get;set;}
        data .. and so on.
        
    }
