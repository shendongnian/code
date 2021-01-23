        public static List<Person> PersonsList = new List<Person>();
        public static Random rd = new Random();
        static void Main(string[] args)
        {
            
            for (int i = 0; i < 5; i++)
            {
                List<string> tmpAbilities = new List<string>() {((char)rd.Next(255)).ToString(), ((char)rd.Next(255)).ToString() , ((char)rd.Next(255)).ToString() };
                Person tmpPerson = new Person("TmpName_"+i,tmpAbilities);
                PersonsList.Add(tmpPerson);
            }
            foreach (var persona in PersonsList)
            {
                Console.WriteLine(persona);
            }
        }
        public class Person
        {
            public string Name { get; set; }
            public List<string> Abilities;
            public Person(string name,List<string> abilities)
            {
                Name = name;
                Abilities = abilities;
            }
            public override string ToString()
            {
                string retVal = $"Name: {Name}\n";
                foreach (var ability in Abilities)
                {
                    retVal += $"Ability : {ability}\n";
                }
                return retVal;
            }
        }
