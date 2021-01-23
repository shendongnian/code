    public class User
    {
       public string Username { get; }
       public string FirstName { get; }
       public string LastName { get; }
    
       public User(string username, string firstName, string lastName)
       {
           // initialize properties
       }
    
       public void Deconstruct(out string username, out string firstName, out string lastName)
       {
           // initialize out parameters
       }
    }
