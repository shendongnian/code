    class Program
    {
        static void Main(string[] args)
        {
            #region SimulatedDb
            // Technically a Food object from the Database
            var myFood = new Food() { Name = "Sub", Ingredients = new List<IngredientViewModel>(), Price = 8.00 };
            // Technically Ingredients from the Database
            var cbSpringMixIn = new Ingredient() { Name = "Spring Mix", Price = 2.00 };
            var cbAvacodoIn = new Ingredient() { Name = "Avacodo", Price = 1.50 };
            var cbBeansIn = new Ingredient() { Name = "Beans", Price = 2.00 };
            #endregion
            // This would actually be in your code
            // You would probably just do a for each statement to turn all of these into 
            // Objects and add them to the list of available ingredients
            var cbSpringMix = new IngredientViewModel(cbSpringMixIn);
            var cbAvacodo = new IngredientViewModel(cbAvacodoIn);
            var cbBeans = new IngredientViewModel(cbBeansIn);
            #region SimulatedUserInterface
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
            #endregion
            // This would actually be in your code
            // You would probably just do a for each statement to turn all of these into 
            // Objects and add them to the list of available ingredients
            myFood.Ingredients.Add(cbAvacodo);
            myFood.Ingredients.Add(cbBeans);
            myFood.Ingredients.Add(cbSpringMix);
            #region SimulatedUserInterfaceContinued
            Console.WriteLine("You are ready to check out! Press any key to continue...");
            var checkout = Console.ReadLine();
            Console.Write("You have ordered a {0} with ", myFood.Name);
            foreach (var ingredient in myFood.GetSelectedNames())
            {
                Console.Write(ingredient + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Your Final Price is:");
            Console.WriteLine(String.Format("{0:C}", myFood.GetFullPrice()));
            Console.ReadLine();
            #endregion
            
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
            public virtual List<IngredientViewModel> Ingredients { get; set; }
        }
        public class IngredientViewModel
        {
            public IngredientViewModel(Ingredient ingredient)
            {
                this.Name = ingredient.Name;
                this.Price = ingredient.Price;
                this.Selected = false;
            }
            public string Name { get; set; }
            public double Price { get; set; }
            public bool Selected { get; set; }
        }
        public class Ingredient
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
    }
}
