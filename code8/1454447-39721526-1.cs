        IEnumerable<Item> GetPartials(Item container, List<Item> collection)
        {
            foreach (Item item in collection)
            {
                if (container.Network == item.Network
                    && container.Title == item.Title)
                // there is obviously also a check on the times, but it's long to write
                {
                    yield return item;
                    collection.Remove(item);//remove already checked item
                }
            }
        }
        public Item Aggregate(Item container, IEnumerable<Item> partials)
        {
            //this is irrelevant
            container.Partials = partials.ToList();
            return container;
        }
        public IEnumerable<Item> FilterAndAggregate(IEnumerable<Item> collection)
        {
            var col = collection as IList<Item> ?? collection.ToList();
            var partials = col.Where(x => x.Type == 2).ToList();
            var notPartials = col.Where(x => x.Type != 2).ToList();
            foreach (Item item in notPartials)
            {
                if (item.Type == 1)
                {
                    yield return Aggregate(item, GetPartials(item, partials));
                }
                else if (item.Type == 3)
                {
                    yield return item;
                }
                // I'm filtering the partials because I already aggregated them
            }
        }
