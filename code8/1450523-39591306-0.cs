    public class User
    {
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
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                User user = new User(name);
                users.Add(user);
            }
        }
    }
