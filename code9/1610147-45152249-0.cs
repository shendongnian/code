    public class UserInformation
    {
        public ICollection<Token> Tokens {get;set;}
    }
    
    public class Token
    {
        public int UserInformationId {get;set;}
        
        public UserInformation UserInfo {get;set;}
    }
  
