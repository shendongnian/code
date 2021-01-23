    public interface ICompanyAddress
    {
        public string Name1 {get; set;}
        public Address Addresses {get; set;}
        //probably other similar stuff
    }
    public class Entity:ICompanyAddress
    {
         //all properties which are needed from the interface
    }
    
    //all other classes with same properties should also inherit ICompanyAddress
    
