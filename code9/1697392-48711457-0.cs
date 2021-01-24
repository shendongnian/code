    public class Item
    {
        public int Id;
        public int NextId;
        public override string ToString()
        {
            return string.Format("Item {0} (links to {1})", Id, NextId);
        }
    };
    class Program
    {
        static void Main(string[] args)
        {
            Item[] items = new Item[] {
                new Item() { Id = 1, NextId = 3 },
                new Item() { Id = 2, NextId = 0 },
                new Item() { Id = 3, NextId = 17 },
                new Item() { Id = 17, NextId = 2 }
            };
            Dictionary<int, int> idToIndex = new Dictionary<int, int>();
            int headId = 0;
            for (int index = 0; index < items.Length; ++index)
            {
                idToIndex.Add(items[index].Id, index);
                headId = headId ^ items[index].NextId ^ items[index].Id;
            }
            int currentId = headId;
            while (currentId != 0)
            {
                var item = items[idToIndex[currentId]];
                Console.WriteLine(item);
                currentId = item.NextId;
            }
        }
    }
