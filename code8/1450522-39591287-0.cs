    namespace L1
    {
        public class Users
        {
            private string username;
    
    
            public Users(string username)
            {
                this.username = username;    
            }
    
            public string Takename() { return username; }    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<Users> users = new List<Users>();
                for(int i=1; i<=4; i++)
                {
                   Console.Write("Enter username: ");
                   Users user = new Users(Console.Readline());
                   users.Add(user);
                }      
            }               
        }
    }
