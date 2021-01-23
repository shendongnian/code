        class Program
        {
            static void Main(string[] args)
            {
    var myFood = new Food() { Name = "Sub", Ingredients = new List<Ingredient>(), Price = 8.00 };
    
                var cbSpringMix = new Ingredient() { Name = "Spring Mix", Price = 2.00, Selected = false };
                var cbAvacodo = new Ingredient() { Name = "Avacodo", Price = 1.50, Selected = false };
                var cbBeans = new Ingredient() { Name = "Beans", Price = 2.00, Selected = false };
    
    
                Console.WriteLine("What would you like on your {0} ({1:C})", myFood.Name, myFood.Price);
                Console.WriteLine();
                Console.WriteLine("Would you like {0} ({1:C})", cbSpringMix.Name, cbSpringMix.Price);
                Console.WriteLine("yes or no");
                var answer = Console.ReadLine();
                if (answer == "yes")
                {
                    cbSpringMix.Selected = true;
                }
                Console.WriteLine();
                Console.WriteLine("Would you like {0} ({1:C})", cbAvacodo.Name, cbAvacodo.Price);
                Console.WriteLine("yes or no");
                var answer1 = Console.ReadLine();
                if (answer1 == "yes")
                {
                    cbAvacodo.Selected = true;
                }
                Console.WriteLine();
                Console.WriteLine("Would you like {0} ({1:C})", cbBeans.Name, cbBeans.Price);
                Console.WriteLine("yes or no");
                var answer2 = Console.ReadLine();
                if (answer2 == "yes")
                {
                    cbBeans.Selected = true;
                }
                myFood.Ingredients.Add(cbAvacodo);
                myFood.Ingredients.Add(cbBeans);
                myFood.Ingredients.Add(cbSpringMix);
    
                Console.WriteLine("You are ready to check out! Press any key to continue...");
                Console.ReadLine();
    
                Console.Write("You have ordered a {0} with ", myFood.Name);
                foreach (var ingredient in myFood.GetSelectedNames())
                {
                    Console.Write(ingredient + " ");
                }
                Console.WriteLine();
    
                Console.WriteLine("Your Final Price is:");
                Console.WriteLine(String.Format("{0:C}", myFood.GetFullPrice()));
                Console.ReadLine();
    }
    
     public class Food
            {
                public Food()
                {
    
                }
                public IEnumerable<string> GetSelectedNames()
                {
                    return (
                        from f in this.Ingredients
                        where f.Selected
                        select f.Name).ToList();
                }
                public IEnumerable<double> GetSelectedValues()
                {
                    return (
                        from f in this.Ingredients
                        where f.Selected
                        select f.Price).ToList();
                }
                public double GetFullPrice()
                {
                    var selectedIngredients = GetSelectedValues();
                    return selectedIngredients.Sum() + this.Price;
                }
                public string Name { get; set; }
                public double Price { get; set; }
    
                public virtual List<Ingredient> Ingredients { get; set; }
    
            }
    
            public class Ingredient
            {
                public string Name { get; set; }
                public double Price { get; set; }
                public bool Selected { get; set; }
    
            }
    
    
        }
    }
