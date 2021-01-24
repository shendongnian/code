            IQueryable<Item> itemsQuery = items.AsQueryable();
            itemsQuery = itemsQuery.Where(x => x.Code == "BBB");
            var bfsQueue = new Queue<Item>(itemsQuery);
            var matchedItemsSet = new HashSet<Item>();
            while (bfsQueue.Count > 0) {
                var item = bfsQueue.Dequeue();
                matchedItemsSet.Add(item);
                var parent = item.Parent;
                if (parent != null && !matchedItemsSet.Contains(parent))
                {
                    bfsQueue.Enqueue(parent);
                }
            }
            foreach (var item in matchedItemsSet) {
                Console.WriteLine(item.Code);
            }
