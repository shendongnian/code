    private static async Task ProcessItem(Item item)
    {
        // actual work here
        // save item as processed in database
        // we need to wait to ensure item not to appear in queue again 
        await Task.Delay(TimeSpan.FromSeconds(EventIntervalInSeconds * 2));
        // clear the processed cache to reduce memory usage
        _processedItemIds.Remove(item.Id);
    }
    public class Item
    {
        public Guid Id { get; set; }
    }
    // temporary cache for items in process
    private static HashSet<Guid> _processedItemIds = new HashSet<Guid>();
    private static IEnumerable<Item> GetItemsFromDB(Timestamped<long> time)
    {
        // log event timing
        Console.WriteLine($"Event # {time.Value} at {time.Timestamp}");
        // return items from DB
        return new[] { new Item { Id = Guid.NewGuid() } };
    }
