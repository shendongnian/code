    public interface IEntity
    {
        string Name {set;get;}
        string Id {set;get;}
    }
    
    public class Person : IEntity 
    {   
        string Name {set;get;}
        string Id {set;get;}
        string Address {set;get;}
    }
    
    public class Department : IEntity 
    {   
        string Name {set;get;}
        string Id {set;get;}
        string Section {set;get;}
    }
