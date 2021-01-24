        static void Main(string[] args)
        {
            var items = new List<object>() {1, 2, 3, 4, 5, 6};
            var containers = new List<List<object>>() { new List<object>(), new List<object>(),  new List<object>()};
            int c = 0; // indexer for container.
            int containerCount = containers.Count;
            for (int i = 0; i < items.Count; i++, c++)
            {
                c = c % containerCount;
                containers[c].Add(items[i]);
            }
        }
