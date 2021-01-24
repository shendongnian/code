    internal class Program {
        public static void Main(string[] args) {
            // these are the same numbers, but you can replace or add some
            const int limit = 100;
            // if you don't know what a dictionary does you should google that
            var resources = new Dictionary<Good, int>();
            // this is the price of the resource
            resources[Good.Copper] = 20;
            resources[Good.Tin] = 15;
            resources[Good.Iron] = 10;
            //resources[Good.Paper] = 8;
            //resources[Good.Plastic] = 6;
            //resources[Good.Water] = 2;
            // Now we want to calculate all possible combinations.
            // We can not just put some loops into each other because when we have 4 instead of 3 resources we would need 4 loops.
            // Instead we will use some concept called recursion.
            // First we sort the resources from expensive to cheap
            var sortedResources = resources.OrderByDescending(x => x.Value);
            // all combinations will be stored in here
            var allSolutions = new List<List<KeyValuePair<Good, int>>>();
            // We will start with the maximum amount of the most expensive good and then lower its amount and check all amount of the other goods.
            var calculator = new CombinationCalculator(limit, sortedResources.ToList(), allSolutions);
            calculator.CalculateCombinationsRecursive(0, 0, new List<KeyValuePair<Good, int>>());
            Console.WriteLine("\nAll solutions calculated, " + allSolutions.Count + " combinations found.");
            Console.ReadKey();
        }
    }
