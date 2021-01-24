        public class Room
        {
            public string Name { get; set; }
            public List<Meal> Meals { get; set; }
        }
        public class Meal
        {
            public string Name { get; set; }
            public int Count { get; set; }
            public List<EXTRA> Extras { get; set; }
         }
        public class EXTRA
        {
            public string Name { get; set; }
            public List<User> UserNames { get; set; }
        }
        public class User
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }
