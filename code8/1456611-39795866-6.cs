    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                int restartInt;
                restartInt = 1;
    
                // Declare all strings
                string elementRequest;
                string restartString;
    
                var elementDictionary = new Dictionary<string, Element>
                {
                    { "Hydrogen", new Element("Hydrogen", "H", 1) },
                    { "Helium", new Element("Helium", "He", 2) },
    		
    				//etc.
    		    };
    
                while (restartInt == 1)
                {
                    Console.WriteLine("What element do you want? Either input it's full name, with a capital letter. E.g 'Hydrogen'");
    
                    elementRequest = Console.ReadLine();
                    var element = elementDictionary[elementRequest];
                    Console.WriteLine("Your element: " + element.Name + " has the element symbol of: " + element.Symbol + " and atomic number of: " + element.AtomicNumber);
    
                    Console.WriteLine("Would you like to try again? Type '1' for yes, and '2' for no.");
                    restartString = Console.ReadLine();
                    int.TryParse(restartString, out restartInt);
                };
            }
        }
    
    
        public class Element
        {
            public string Name { get; set; }
            public string Symbol { get; set; }
            public int AtomicNumber { get; set; }
    
            public Element(string name, string symbol, int atomicNumber)
            {
                Name = name;
                Symbol = symbol;
                AtomicNumber = atomicNumber;
            }
        }
    }
