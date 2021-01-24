    class theClass
    {
        public string name { get; }
        public string dob { get; }
        public int age { get; }
        public theClass(string name,int age, string dob)
        {
            this.name = name;
            this.age = age;
            this.dob=dob;
        }
        public string canVote()
        {
            if (age >= 18)
                return "Can Vote";
            else
                return "Cannot Vote";
        }
    }
    
    public class Solution
    {
        public static void Main()
        {
            Dictionary<string, theClass> d = new Dictionary<string, theClass>();
            theClass object1 = new theClass("John",16,"Chennai");
            theClass object2 = new theClass("Smita",22, "Delhi");
            theClass object3 = new theClass("Vincent",25, "Banglore");
            theClass object4 = new theClass("Jothi", 10, "Banglore");
            d.Add("John", object1);
            d.Add("Smita", object2);
            d.Add("Vincent", object3);
            d.Add("Jothi", object4);
            foreach (var person in d.Values)
            {
                Console.WriteLine($"{person.name} : {person.canVote()}");
            }
            Console.ReadKey();
        }
    }
