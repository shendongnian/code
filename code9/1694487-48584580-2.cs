    internal class CombinationCalculator {
        private readonly List<List<KeyValuePair<Good, int>>> _allSolutions;
        private readonly int _limit;
        private readonly List<KeyValuePair<Good, int>> _sortedResources;
        /// <summary>
        ///     This class will calculate all combinations
        /// </summary>
        /// <param name="limit">The minimum cost (100 for example)</param>
        /// <param name="sortedResources">All resources and their individual price sorted descending.</param>
        /// <param name="allSolutions">all completed combinations of resources and each amount.</param>
        public CombinationCalculator(int limit, List<KeyValuePair<Good, int>> sortedResources, List<List<KeyValuePair<Good, int>>> allSolutions) {
            _limit = limit;
            _sortedResources = sortedResources;
            _allSolutions = allSolutions;
        }
        /// <summary>
        ///     Find all combinations recursive.
        /// </summary>
        /// <param name="index">The resource that should be added next.</param>
        /// <param name="currentPrice">The price what the resources that are already added cost.</param>
        /// <param name="resources">All resources that are already added and their amount.</param>
        internal void CalculateCombinationsRecursive(int index, int currentPrice, List<KeyValuePair<Good, int>> resources) {
            // we calculate the amount af this resource needed to get atleast the limit
            var maximumAmount = (int)Math.Ceiling((_limit - currentPrice) / (1.0 * _sortedResources[index].Value));
            // with maximum amount you have one combination already
            var firstCombi = resources.ToList();
            firstCombi.Add(new KeyValuePair<Good, int>(_sortedResources[index].Key, maximumAmount));
            Console.WriteLine("Found one combination: ");
            foreach(var res in firstCombi) {
                Console.Write(" " + res.Key + " * " + res.Value + ",");
            }
            Console.WriteLine(" price: " + (currentPrice + maximumAmount * _sortedResources[index].Value));
            _allSolutions.Add(firstCombi);
            // if this is already the last resource we can't add more
            if(index == _sortedResources.Count - 1) {
                return;
            }
            // now find all other possible combinations recursive
            for(var i = maximumAmount - 1; i >= 0; i--) {
                // since we add less than maximum amount we will need to fill the price with the other resources
                var newResources = resources.ToList();
                newResources.Add(new KeyValuePair<Good, int>(_sortedResources[index].Key, i));
                // this method calls itself recursive
                CalculateCombinationsRecursive(index + 1, currentPrice + i * _sortedResources[index].Value, newResources);
            }
        }
    }
