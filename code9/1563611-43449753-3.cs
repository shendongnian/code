    public interface IHasRole
    {
         string Role { get; set; }
    }
    
    public class Employee : Person, IHasRole
    {
        public string Role { get; set; }
    }
