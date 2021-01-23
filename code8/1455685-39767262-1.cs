	using System;
	using System.Collections.Generic;
	namespace Chemistry_Element_Calculator
	{
        // Create a chemical element class
        // You can add more properties such as number of electrons, etc.
		public class ChemicalElement
		{
			public string Symbol
			{
				get; set;
			}
			public string Name
			{
				get; set;
			}
		}
		class Program
		{
			static void Main(string[] args)
			{
                // Create a list of the elements, populate their properties
				var elements = new List<ChemicalElement>()
				{
					new ChemicalElement {Name = "Hydrogen", Symbol = "H"},
					new ChemicalElement {Name = "Helium", Symbol = "He"},
					new ChemicalElement {Name = "Lithium", Symbol = "Li"}
                    // etc.
				};
				Console.WriteLine("What element do you want? Either input it's full name, with a capital letter, or it's elemnent symbol. E.g. N for Nitrogen");
				var elementRequest = Console.ReadLine();
                // Use find to get a matching element, compare both name and symbol
				var foundElement = elements.Find(element => element.Symbol == elementRequest || element.Name == elementRequest);
				if (foundElement == null)
				{
                    // Output if no element is found
					Console.WriteLine("Element Not Found");
				}
				else
				{
                    // Output if the element is found
					Console.WriteLine("Found element {0}.", foundElement.Name);
				}
                
				Console.WriteLine("[Press any key to finish]");
				Console.ReadKey();
			}
		}
	}
