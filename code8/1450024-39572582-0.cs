    namespace TestProject
    {
        public class User
        {
            public string Username {get; set;}
            public string Password {get; set;}
            public datetime LastLoginDate {get;set;}
    
            public void SetLastLogin()
            {
                LastLoginDate = datetime.now;
           }
        }
    }
