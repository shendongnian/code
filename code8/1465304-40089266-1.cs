    class RootObject
    {
       public string ParentName { get; set; }
       public Dictionary<string, User> users { get; set; }
    }
    class User
    {
       public string name { get; set; }
       public string state { get; set; }
       public string id { get; set; }
       public string ParentName { get; set; }
    } 
   
