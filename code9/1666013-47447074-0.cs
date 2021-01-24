    public class ActionResultExtended
    {
       public string ErrorCode { get; set; }
       public string ErrorMessage { get; set; }
       public User Result { get; set; }
    }
    
    public class User
    {
       public string Username { get; set; }
       public string Interest { get; set; }
       public string Position { get; set; }
    }
