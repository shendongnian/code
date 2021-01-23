        IEnumerable<Item> GetPartials(Item container, List<Item> collection)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (container.Network == collection[i].Network
                    && container.Title == collection[i].Title)
                // there is obviously also a check on the times, but it's long to write
                {
                    yield return collection[i];
                    collection.RemoveAt(i);//remove already checked item
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
