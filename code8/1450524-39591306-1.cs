    // Renamed to User as we are representing only one user
    public class User
    {
        // Renamed from userName to Name
        // Made a string to be consistent with the constructor
        // Made it a public property
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }
        public string TakenName() { return Name; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            // for loops in c# typically are zero based
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                User user = new User(name);
                users.Add(user);
            }
        }
    }
