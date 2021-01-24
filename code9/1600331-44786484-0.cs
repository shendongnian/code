    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace p44785433
    {
    class Program
    {
        static List<User> userList = UserFactory.GenerateUsers();
        static void Main(string[] args)
        {
            Console.WriteLine("Number Of Users: {0}", userList.Count);
            var x = getGameList(userList); // 1600 on output
            var y = getGameListUpdated(userList); // 1600< on output depend of randomized empty name
            var z = getGameListLinq(userList); // 1600< on output depend of randomized empty name
        }
        private static List<String> getGameList(List<User>  parUserList)
        {
            List<string> allgames = new List<string>();
            List<User> userlist = /*e.Server.Users.ToList();*/ parUserList;
            foreach (User u in userlist)
            {
                if (u.CurrentGame.ToString() != "")
                {
                    if (u.CurrentGame.Value.Name != null)
                    {
                        allgames.Insert(0, u.CurrentGame.Value.Name);
                    }
                }
            }
            return allgames;
        }
        private static List<String> getGameListUpdated(List<User> parUserList)
        {
            List<string> allgames = new List<string>();
            List<User> userlist = /*e.Server.Users.ToList();*/ parUserList;
            foreach (User u in userlist)
            {
                if (!string.IsNullOrEmpty(u.CurrentGame.ToString()))
                {
                    if (!string.IsNullOrEmpty(u.CurrentGame.Value.Name))
                    {
                        allgames.Insert(0, u.CurrentGame.Value.Name);
                    }
                }
            }
            return allgames;
        }
        private static List<String> getGameListLinq(List<User> parUserList)
        {            
            List<User> userlist = /*e.Server.Users.ToList();*/ parUserList;
            var x = userList.Where(r => !string.IsNullOrEmpty(r.CurrentGame.ToString()) && !string.IsNullOrEmpty(r.CurrentGame.Value.Name)); // remove empty
            var y = x.Select(r => r.CurrentGame.Value.Name); // select strings
            var z = y.Reverse(); // reverse order instead of insert
            return z.ToList();
        }
    }
    internal class User
    {
        public Game CurrentGame { get; set; }
        public string Par1 { get; set; }
        public string Par2 { get; set; }
        public string Par3 { get; set; }
        public string Par4 { get; set; }
        public string Par5 { get; set; }
        public string Par6 { get; set; }
        public string Par7 { get; set; }
        public string Par8 { get; set; }
        public string Par9 { get; set; }
        public string Par10 { get; set; }
        public string Par11 { get; set; }
        public string Par12 { get; set; }
        public string Par13 { get; set; }
        public string Par14 { get; set; }
        internal static User CreateDummy()
        {
            return  new User()
            {
                CurrentGame = Game.CreateDummy(),
                Par6 = UserFactory.Rnd.NextDouble().ToString(),
                Par12 = UserFactory.Rnd.NextDouble().ToString()
            };
        }
    }
    internal static class UserFactory
    {
        static Random _rnd;
        internal static Random Rnd
        {
            get
            {
                if (_rnd == null) _rnd = new Random();
                return _rnd;
            }
        }
        internal static List<User> GenerateUsers()
        {
            List<User> list = new List<User>();
            for (int i = 0; i < (int)1600; i++)
            {
                list.Add(User.CreateDummy());
            }
            return list;
        }
    }
    internal class Game
    {
        public Value Value { get; set; }
        public string Par1 { get; set; }
        public string Par2 { get; set; }
        public string Par3 { get; set; }
        public string Par4 { get; set; }
        public string Par5 { get; set; }
        public string Par6 { get; set; }
        public string Par7 { get; set; }
        public string Par8 { get; set; }
        public string Par9 { get; set; }
        public string Par10 { get; set; }
        public string Par11 { get; set; }
        public string Par12 { get; set; }
        public string Par13 { get; set; }
        public string Par14 { get; set; }
        public override string ToString()
        {
            return Par6;
        }
        internal static Game CreateDummy()
        {
            return new Game()
            {
                Value = Value.CreateDummy(),
                Par6 = UserFactory.Rnd.NextDouble().ToString(),
                Par12 = UserFactory.Rnd.NextDouble().ToString()
            };
        }
    }
    internal class Value
    {
        public string Name { get; set; }
        public string Par1 { get; set; }
        public string Par2 { get; set; }
        public string Par3 { get; set; }
        public string Par4 { get; set; }
        public string Par5 { get; set; }
        public string Par6 { get; set; }
        public string Par7 { get; set; }
        public string Par8 { get; set; }
        public string Par9 { get; set; }
        public string Par10 { get; set; }
        public string Par11 { get; set; }
        public string Par12 { get; set; }
        public string Par13 { get; set; }
        public string Par14 { get; set; }
        internal static Value CreateDummy()
        {
            return new Value()
            {
                Name = (UserFactory.Rnd.Next(10)!=0 ? string.Format("XXA{0}XAA", UserFactory.Rnd.NextDouble()): string.Empty),
                Par5 = UserFactory.Rnd.NextDouble().ToString(),
                Par11 = UserFactory.Rnd.NextDouble().ToString()
            };
        }
    }
}
