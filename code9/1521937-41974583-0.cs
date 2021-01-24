    public class DogDb
    {
        // DogDb contains a list of dogs
        public List<Dog> dogs { get; set; }
        public DogDb() {
            dogs = new List<Dog>();
        }
        // DogDb can control adding new dogs to its list of dogs.
        public void addDog(string name, int age, string sex, string breed, string colour, int weight)
        {               
                    
            dogs.Add(new Dog()
            {
                name = name,
                age = age,
                sex = sex,
                breed = breed,
                colour = colour,
                weight = weight
            });
        }
        public class Dog
        {
            public string name { get; set; }
            public int age { get; set; }
            public string sex { get; set; }
            public string breed { get; set; }
            public string colour { get; set; }
            public int weight { get; set; }
        }
    }
    public class Program
    {
          public static void Main(string[] args)
        {
        // Create a new instance of our DogDB class.
        var DogDb = new DogDb();
        // Get user input
        Console.WriteLine("Dogs Name:");
        string inputName = Console.ReadLine();
        Console.WriteLine("Dogs Age:");
        int inputAge = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Dogs Sex:");
        string inputSex = Console.ReadLine();
        Console.WriteLine("Dogs Breed:");
        string inputBreed = Console.ReadLine();
        Console.WriteLine("Dogs Colour:");
        string inputColour = Console.ReadLine();
        Console.WriteLine("Dogs Weight:");
        int inputWeight = Convert.ToInt32(Console.ReadLine());
        // add input to the object.
        DogDb.addDog(inputName, inputAge, inputSex, inputBreed, inputColour, inputWeight);
    }
