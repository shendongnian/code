    namespace World
    {
        public class Human
        {
            // Personal traits
            public string first_name;
            public string last_name;
            public string full_name { get { return first_name + " " + last_name}};
        }
    }
