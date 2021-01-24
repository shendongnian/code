    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication4
    {
        namespace DoggyDatabase
        {
            public class Program
            {
                private static List<Dog> dogList = new List<Dog>();
                public static void Main(string[] args)
                {
                    // create the list using the Dog class                
    
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
    
                    // add input to the list.
                    addDog(inputName, inputAge, inputSex, inputBreed, inputColour, inputWeight);
                }
    
                public static void addDog(string name, int age, string sex, string breed, string colour, int weight)
                {
                    // The name 'dogList' does not exist in the current context
                    dogList.Add(new Dog()
                    {
                        name = name,
                        age = age,
                        sex = sex,
                        breed = breed,
                        colour = colour,
                        weight = weight
                    });
                }
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
    }
