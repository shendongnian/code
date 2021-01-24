    public class DogDatabase
    {
        private static List<Dog> dogs = new List<Dog>();
        public static void dogList()
        {
            //lists the Dog class from above
            dogs.Add(new Dog("Baxter", "blue", "me"));
            dogs.Add(new Dog("Fido", "Black", "peter"));  
        }
        public static void print()
        {                
            //the foreach loops for printing the list
            foreach (Dog printDog in dogs)
            {
                Console.WriteLine(printDog.name + " " + printDog.colour);
            }
        }
    }
