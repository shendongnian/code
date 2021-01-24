    public static void Test()
        {
            var goal = 25;
            var products = new[]
            {
                new Product() { ID = 1, Qty = 5 },
                new Product() { ID = 2, Qty = 5 },
                new Product() { ID = 3, Qty = 8 },
                new Product() { ID = 4, Qty = 15 },
                new Product() { ID = 5, Qty = 17 },
                new Product() { ID = 6, Qty = 1 },
                new Product() { ID = 7, Qty = 4 },
                new Product() { ID = 8, Qty = 6 },
            };
            var orderedProducts = products.OrderBy(prod => prod.ID);
            //one un-completed combination, can bring back muliple combination..
            //that include completed or next-staged-uncompleted combinations
            Func<Combination, IEnumerable<Combination>> job = null;
            job = (set) =>
            {
                if (set.IsCompleted)
                    return new[] { set }.ToList();
                else
                {
                    return orderedProducts
                        .Where(product => set.Contains(product) == false && product.ID >= set.Last().ID)
                        .Select(product => new Combination(set, product))
                        .SelectMany(combination => job(combination));
                }
            };
            var allPossibility = orderedProducts
                .Select(product => new Combination(goal, product))
                .SelectMany(combination => job(combination))
                .Where(combination => combination.IsCompleted)
                .Select(combination => new Combination(goal, combination.OrderBy(product => product.ID).ToArray()))
                .OrderBy(item => item)
                .ToList();
            foreach (var completedCombination in allPossibility)
            {
                Console.WriteLine(string.Join<int>(", ", completedCombination.Select(prod => prod.ID).ToArray()));
            }
            Console.ReadKey();
        }
