    public class Person
    {
        public string Name { get; set; }
        public string Pass { get; set; }
        public Person(string name = " ", string pass = " ")
        {
            Name = name;
            Pass = pass;
        }
        public string Ts()
        {
            string s = "";
            s += Name;
            s += " ";
            s += Pass;
            return s;
        }
    }
