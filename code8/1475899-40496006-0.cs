    public static T Get<T>(this Person person, string name)
    {
        return (T)person.NewFirstName(name);
    }
    var p = new Person("Tim");   
    p.LastName = "Meier"; 
    
    var IsOlivia = p.Get<bool>("Olivia"); // works 
