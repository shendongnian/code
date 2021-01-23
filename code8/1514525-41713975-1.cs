    public class Program
    {
        public enum Roles
        {
            Admin, 
            Secretary, 
            Treasurer
        }
        
        public class User
        {
            public Roles Role { get; set; }
        }
        
        public static void Main(string[] args)
        {
            User bob = new User(){ Role = Roles.Admin };
            
            switch (bob.Role)
            {
                case Roles.Admin:
                    Console.WriteLine("This user is an Admin (use the admin login)");
                    break;
                case Roles.Secretary:
                    Console.WriteLine("This user is a Secretary (use the secretary login)");
                    break;
                case Roles.Treasurer:
                    Console.WriteLine("This user is a Treasurer (use the treasurer login)");
                    break;
            }
        }
    }
